﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.ResultViewModel.RegisterViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="O nome é um atributo obrigatório.")]
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage ="Email digitado invalido.")]
        [Required(ErrorMessage ="o Email é um atributo obrigatório.")]
        public string Email { get; set; }
        [Required(ErrorMessage ="A senha é um atributo obrigatorio.")]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
