using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly JWT _jwt;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<User> _passwordHasher;
        public UserService(IOptions<JWT>  jwt, IUnitOfWork unitOfWork, IPasswordHasher<User> passwordHasher)
            {
                _jwt = jwt.Value;
                _unitOfWork = unitOfWork;
                _passwordHasher = passwordHasher;
            }
            // variable de tipo user, toma del dto tantoel correo como el nombre, y la contraseña encriptada se va a agregar de manera automatica por medio del hasher basado en lo que le estamos passando 
            public async Task<string> RegisterAsync(RegisterDto registerDto)
            {
                var user = new User
                {
                    Email = registerDto.Email,
                    UserName = registerDto.UserName,

                };

                user.Password =  _passwordHasher.HashPassword(user,registerDto.Password);
                var userExists = _unitOfWork.Users
                                                .Find(u => u.UserName.ToLower() == registerDto.UserName.ToLower())
                                                .FirstOrDefault();
                if( userExists == null)
                {
                try
                {
                    //user.Rols.Add(rolPredeterminado)
                    _unitOfWork.Users.Add(user);
                    await _unitOfWork.SaveAsync();

                    return $"El Usuario {registerDto.UserName} ha sido registrado exitosamente";

                }
                catch (Exception ex)
                {
                    var message = ex.Message;
                    return $"Error: {message}";
                }
                }
                else
                {
                    return $"El Usuario {registerDto.UserName} ya existe";
                }

            }
            public async Task<string> AddRoleAsync(AddRolDto model)
            {
                var user = await _unitOfWork.Users
                                .GetByUsernameAsync(model.UserName);
                if (user == null)
                {
                    return $"El Usuario {model.UserName} no existe";
                }

                var resultado =  _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password);
                if (resultado == PasswordVerificationResult.Success)
                {
                    var rolExist = _unitOfWork.Rols
                                                .Find(r => r.Name.ToLower() == model.Rol.ToLower())
                                                .FirstOrDefault();  
                    if(rolExist != null)
                    {
                        var userHasRol = user.Rols

                                                .Any(u => u.Id == rolExist.Id);

                        if(userHasRol == false)
                        {
                            user.Rols.Add(rolExist);
                            _unitOfWork.Users.Update(user);
                            await _unitOfWork.SaveAsync();
                        }
                
                        return $"Rol {model.Rol} agregado a la cuenta {model.UserName} de forma exitosa";
                
                    }
                    return $"Rol {model.Rol} no encotrado";
                }
                return $"Credenciales incorrectas para el usuario {user.UserName}.";
            }

            public async Task<DatosUsuarioDto> GetTokenAsync(LoginDto model)
            {
                DatosUsuarioDto datosUsuarioDto = new DatosUsuarioDto();
                var user = await _unitOfWork.Users
                            .GetByUsernameAsync(model.Username);

                if(user == null)
                {
                    datosUsuarioDto.IsAuthenticated = false;
                    datosUsuarioDto.Message = $"No existe ningún usuario con el username {model.Username}.";
                    return datosUsuarioDto;
            
                }

                var result = _passwordHasher.VerifyHashedPassword(user,user.Password, model.Password);
            
                if(result == PasswordVerificationResult.Success)
                {
                    datosUsuarioDto.IsAuthenticated = true;
                    JwtSecurityToken jwtSecurityToken = CreateJwtToken(user);
                    datosUsuarioDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                    datosUsuarioDto.Email = user.Email;
                    datosUsuarioDto.UserName = user.UserName;
                    datosUsuarioDto.Rols = user.Rols
                                                .Select(u => u.Name)
                                                .ToList();
                    return datosUsuarioDto;
                }            
            
                datosUsuarioDto.IsAuthenticated = false;
                datosUsuarioDto.Message = $"Credenciales incorrectas para el usuario {user.UserName}";
                return datosUsuarioDto;
            } 

            private JwtSecurityToken CreateJwtToken(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "El user no puede ser nulo.");
            }

            var rols = user.Rols;
            var roleClaims = new List<Claim>();
            foreach (var rol in rols)
            {
                roleClaims.Add(new Claim("rols", rol.Name));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("uid", user.Id.ToString())
            }
            .Union(roleClaims);

            if (string.IsNullOrEmpty(_jwt.Key) || string.IsNullOrEmpty(_jwt.Issuer) || string.IsNullOrEmpty(_jwt.Audience))
            {
                throw new ArgumentNullException("La configuración del JWT es nula o vacía.");
            }

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var JwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials);

            return JwtSecurityToken;
            }

        }
    }

