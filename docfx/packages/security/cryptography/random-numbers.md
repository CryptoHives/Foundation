# Random Number Generation

`RandomNumberGenerator` in `CryptoHives.Foundation.Security.Cryptography.Rng` fills buffers with
cryptographically strong random bytes. It generates nothing itself: every byte comes from the
platform generator behind `System.Security.Cryptography.RandomNumberGenerator.Create()`.

**Namespace:** `CryptoHives.Foundation.Security.Cryptography.Rng` · [API reference](xref:CryptoHives.Foundation.Security.Cryptography.Rng.RandomNumberGenerator)

## Why it exists

The in-box static `RandomNumberGenerator.Fill(Span<byte>)` arrived with .NET Standard 2.1, so code
that fills a span cannot call it on .NET Framework 4.6.2/4.7.2 or .NET Standard 2.0, which this
package also targets. This type offers the same call on every target framework, and the library
uses it wherever it draws randomness of its own:

- keys and IVs from `SymmetricCipher.GenerateKey()` / `GenerateIV()`
- the salt and IV of an encrypted PKCS#8 export
- the random bytes of ISO 10126 padding
- below .NET 8, the randomness of ML-KEM key generation and encapsulation, and of ML-DSA and
  SLH-DSA key generation and hedged signing

## Usage

```csharp
using CryptoHives.Foundation.Security.Cryptography.Rng;

byte[] nonce = new byte[12];
RandomNumberGenerator.Fill(nonce);

Span<byte> key = stackalloc byte[32];
RandomNumberGenerator.Fill(key);
```

The static `Fill` overloads share one generator for the whole process, need no instance, and are
safe to call from several threads at once. Prefer them. `Create()` returns an instance with
`GetBytes(byte[])`, `GetBytes(byte[], int, int)` and `GetBytes(Span<byte>)`, for code that is
written against an instance; dispose it when done. After `Dispose` its `GetBytes` overloads throw
`ObjectDisposedException`; the static `Fill` is unaffected.

## Members

| Member | Notes |
|---|---|
| `static void Fill(Span<byte> data)` | Same name and shape as the in-box static |
| `static void Fill(byte[] data)` | Not in the in-box type; throws `ArgumentNullException` for `null` |
| `static RandomNumberGenerator Create()` | |
| `void GetBytes(byte[] data)` / `GetBytes(byte[] data, int offset, int count)` | Forward to the platform generator |
| `void GetBytes(Span<byte> data)` | Before .NET 6, staged through a rented `ArrayPool<byte>` array that is cleared before it goes back |
| `void Dispose()` | Afterwards the `GetBytes` overloads throw `ObjectDisposedException`; safe to call twice |

The in-box convenience members are **not** here: `GetBytes(int)`, `GetInt32`, `GetNonZeroBytes`,
`GetItems`, `GetString`, `GetHexString` and `Shuffle`. To get a fresh array, allocate it and call
`Fill`:

```csharp
byte[] salt = new byte[16];
RandomNumberGenerator.Fill(salt);
```

## Using it next to the in-box type

It wraps `System.Security.Cryptography.RandomNumberGenerator` rather than deriving from it, so an
instance cannot be passed to an API that expects the in-box type. Where an API wants one, pass the
in-box generator itself.

Because the names match, a file that imports both namespaces gets `CS0104` on
`RandomNumberGenerator`. Alias one side:

```csharp
using CryptoHives.Foundation.Security.Cryptography.Rng;
using Bcl = System.Security.Cryptography;

RandomNumberGenerator.Fill(nonce);        // this package
using var platform = Bcl.RandomNumberGenerator.Create();
```

On .NET Standard 2.1 and later, `System.Security.Cryptography.RandomNumberGenerator.Fill(Span<byte>)`
draws from the same platform generator, so code that only targets those frameworks gains nothing by
switching.

## See Also

- [Cipher Algorithms](cipher-algorithms.md)
- [Erasable Memory](erasable-memory.md)
