Imports System.Security.Cryptography
Imports System.Text

Public Class CryptoHelper
    Private Shared ReadOnly key As String = "12345678901234567890123456789012" ' 32 karakter
    Private Shared ReadOnly iv As String = "1234567890123456" ' 16 karakter

    Public Shared Function Encrypt(plainText As String) As String
        Using aes As Aes = aes.Create()
            aes.Key = Encoding.UTF8.GetBytes(key)
            aes.IV = Encoding.UTF8.GetBytes(iv)
            aes.Padding = PaddingMode.PKCS7

            Dim encryptor = aes.CreateEncryptor()
            Dim inputBytes = Encoding.UTF8.GetBytes(plainText)
            Dim encrypted = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length)
            Return Convert.ToBase64String(encrypted)
        End Using
    End Function

    Public Shared Function Decrypt(encryptedText As String) As String
        Using aes As Aes = aes.Create()
            aes.Key = Encoding.UTF8.GetBytes(key)
            aes.IV = Encoding.UTF8.GetBytes(iv)
            aes.Padding = PaddingMode.PKCS7

            Dim decryptor = aes.CreateDecryptor()
            Dim encryptedBytes = Convert.FromBase64String(encryptedText)
            Dim decrypted = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length)
            Return Encoding.UTF8.GetString(decrypted)
        End Using
    End Function
End Class
