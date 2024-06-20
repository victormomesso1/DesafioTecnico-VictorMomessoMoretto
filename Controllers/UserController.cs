using API_RandomUser.DTOs;
using API_RandomUser.Interfaces;
using API_RandomUser.Models;
using API_RandomUser.Services;
using API_RandomUser.Token;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace API_RandomUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly JwtService _jwtService;

        public UserController(IUserService userService, ILogger<UserController> logger, JwtService jwtService)
        {
            _userService = userService;
            _logger = logger;
            _jwtService = jwtService;
        }

        /// <returns>Lista de todos os usuarios</returns>
        [HttpGet("ConsumirTodosUsuarios")]
        
        public async Task<ActionResult<IEnumerable<ResultDto>>> GetUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                if (users == null || users.Count == 0)
                {
                    _logger.LogWarning("Nenhum usuário encontrado.");
                    return NotFound("Nenhum usuário encontrado.");
                }

                _logger.LogInformation("Usuários recuperados com sucesso.");
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao recuperar usuários.");
                return StatusCode(500, "Erro ao recuperar usuários.");
            }
        }

        /// <summary>
        /// importar users aleatorios da API externa
        /// </summary>
        [HttpPost("ImportarDaAPI_Random_User")]
        public async Task<ActionResult> ImportUsers()
        {
            try
            {
                string apiUrl = "https://randomuser.me/api/";
                var users = await _userService.FetchUsersFromAPI(apiUrl);
                if (users == null || users.Count == 0)
                {
                    _logger.LogWarning("Nenhum usuário retornado da API.");
                    return BadRequest("Nenhum usuário retornado da API.");
                }

                foreach (var user in users)
                {
                    await _userService.CreateUserAsync(user);
                }

                _logger.LogInformation("Dados inseridos com sucesso no banco de dados.");
                return Ok("Dados inseridos com sucesso no banco de dados.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao importar usuários.");
                return StatusCode(500, "Erro ao importar usuários.");
            }
        }
        /// <summary>
        /// Registra um novo usuario.
        /// </summary>
        [HttpPost("register - Para logar posteriormente")]
        public async Task<IActionResult> RegisterUser(RegisterToken registerToken)
        {
            try
            {
                await _userService.RegisterUserAsync(registerToken);
                return Ok("Usuário registrado com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao registrar usuário.");
                return StatusCode(500, "Erro ao registrar usuário.");
            }
        }
        /// <summary>
        /// Login e gera JWT Token.
        /// </summary>
        /// <param name="loginToken"> O Login contem autenticação por email e senha.</param>
        /// <returns> Um JWT Token.</returns>
        [HttpPost("logar - Para gerar Token JWT")]
        public async Task<ActionResult> Login([FromBody] RegisterToken loginToken)
        {
            try
            {
                var user = await _userService.AuthenticateUserAsync(loginToken.email, loginToken.password);

                if (user == null)
                {
                    _logger.LogWarning("Email ou senha inválidos.");
                    return Unauthorized("Email ou senha inválidos.");
                }

                var token = _jwtService.GenerateJwtToken(user.email, user.email);
                _logger.LogInformation("Login bem-sucedido.");
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao fazer login.");
                return StatusCode(500, "Erro ao fazer login.");
            }
        }
    }
}