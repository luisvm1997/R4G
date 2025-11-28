using Microsoft.AspNetCore.Identity;

namespace R4G.App.Identity;

/// <summary>
/// Mensajes de validación de Identity traducidos al español.
/// </summary>
public class SpanishIdentityErrorDescriber : IdentityErrorDescriber
{
    public override IdentityError DuplicateUserName(string userName) =>
        new IdentityError
        {
            Code = nameof(DuplicateUserName),
            Description = $"El usuario '{userName}' ya existe."
        };

    public override IdentityError DuplicateEmail(string email) =>
        new IdentityError
        {
            Code = nameof(DuplicateEmail),
            Description = $"El email '{email}' ya está registrado."
        };

    public override IdentityError InvalidEmail(string? email) =>
        new IdentityError
        {
            Code = nameof(InvalidEmail),
            Description = $"El email '{email}' no es válido."
        };

    public override IdentityError PasswordTooShort(int length) =>
        new IdentityError
        {
            Code = nameof(PasswordTooShort),
            Description = $"La contraseña debe tener al menos {length} caracteres."
        };

    public override IdentityError PasswordRequiresDigit() =>
        new IdentityError
        {
            Code = nameof(PasswordRequiresDigit),
            Description = "La contraseña debe contener al menos un número."
        };

    public override IdentityError PasswordRequiresLower() =>
        new IdentityError
        {
            Code = nameof(PasswordRequiresLower),
            Description = "La contraseña debe contener al menos una letra minúscula."
        };

    public override IdentityError PasswordRequiresUpper() =>
        new IdentityError
        {
            Code = nameof(PasswordRequiresUpper),
            Description = "La contraseña debe contener al menos una letra mayúscula."
        };

    public override IdentityError PasswordRequiresNonAlphanumeric() =>
        new IdentityError
        {
            Code = nameof(PasswordRequiresNonAlphanumeric),
            Description = "La contraseña debe incluir un carácter especial."
        };

    public override IdentityError PasswordMismatch() =>
        new IdentityError
        {
            Code = nameof(PasswordMismatch),
            Description = "La contraseña y la confirmación no coinciden."
        };
}
