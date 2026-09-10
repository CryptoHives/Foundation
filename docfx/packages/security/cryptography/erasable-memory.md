# Erasable Memory and the Dropped `string` API

The PQC key-format surface on `MLKem`, `MLDsa` and `SlhDsa` follows one rule: **no member takes a
password, or returns a plaintext private key, as a `string`.**

A `string` is immutable. Once a password or a PEM-encoded private key is inside one, nothing — not
the caller, not this library, not `Dispose` — can overwrite it. It sits on the managed heap until the
garbage collector happens to reuse that memory, which may be after a process dump, a page to disk, or
a crash report.

## This is the BCL's rule, not ours

It would be easy to read the section above as a deliberate divergence from .NET. It is the opposite.
`System.Security.Cryptography.AsymmetricAlgorithm` — the base that `RSA`, `ECDsa` and `DSA` inherit,
and the most heavily reviewed key-format surface Microsoft ships — **has never had a `string`
password overload**, and it has offered `Span<char>` PEM exports since they were introduced:

| | `AsymmetricAlgorithm`<br/>(RSA, ECDsa, DSA) | in-box `MLDsa`/`MLKem`/`SlhDsa`<br/>(.NET 10) | this library |
|---|---|---|---|
| `string` password parameters | **none** | **5** | **none** |
| `ImportFromPem(string)` | no | yes | no |
| `TryExportPkcs8PrivateKeyPem(Span<char>)` | yes | **no** | yes |
| `TryExportSubjectPublicKeyInfoPem(Span<char>)` | yes | **no** | yes |
| `TryExportEncryptedPkcs8PrivateKeyPem(…, Span<char>)` | yes | **no** | yes |
| `string ExportPkcs8PrivateKeyPem()` | yes | yes | **no** |

On every row but the last, this library matches `AsymmetricAlgorithm` and the in-box PQC types do
not. The last row is the one place `AsymmetricAlgorithm` is also weaker than it could be: it offers
both the allocating plaintext-PEM export and the erasable one, and we offer only the erasable one.

### Why the in-box PQC types went off the known track

This is on the record, not inferred.

The original API proposal for `MLKem` ([dotnet/runtime#113508](https://github.com/dotnet/runtime/issues/113508))
contained **no `string` password parameter at all** — only `ReadOnlySpan<char>` and
`ReadOnlySpan<byte>`, exactly as `AsymmetricAlgorithm` has always had them. The `string` overloads
were added later, and the reason is stated in the amendment that finalised them
([dotnet/runtime#115024](https://github.com/dotnet/runtime/issues/115024), API-approved):

> We decided that, since **the string overloads for password exist purely for ease-of-use for other
> downlevel platforms**, that one should take a byte array instead of a `ReadOnlySpan`. There is
> already an overload that accepts `ReadOnlySpan<char>`, `ReadOnlySpan<byte>`, so modern targets
> still have access to all the span APIs that they want.

So the `string` overloads are a **downlevel-ergonomics affordance**: the PQC types ship to .NET
Framework and .NET Standard 2.0 through `Microsoft.Bcl.Cryptography`, where spans are more awkward to
use, and the `string` overloads exist to smooth that over. `AsymmetricAlgorithm` never needed the
same concession because its shape predates that porting effort.

The irony is not lost on us. **This library targets those same downlevel platforms** — net462
upward — and reached the opposite conclusion: the platforms where spans are least convenient are
also the platforms where an unerasable password is no less dangerous, and convenience is a poor
trade for a secret that cannot be overwritten. The `ReadOnlySpan<char>` overload works on every one
of those targets; it just costs the caller an `.AsSpan()` or a `char[]`.

The missing `Span<char>` PEM exports have a simpler explanation: `MLKem`, `MLDsa` and `SlhDsa` are
**not** `AsymmetricAlgorithm` subclasses and could not be — its `KeySize`, `LegalKeySizes`,
`SignatureAlgorithm` and XML key formats mean nothing for a KEM, or for a signature scheme whose
parameter set fixes every size in advance. The key-format block was therefore written fresh rather
than inherited, and the three `TryExport*Pem` members did not make the copy. The original proposal
does not list them either.

This library is standalone for the same reason, and used that freedom to follow the older shape.

### Can a `string` just be overwritten?

Mechanically yes, and it is a bad idea. `MemoryMarshal.AsMemory(s.AsMemory()).Span` hands out a
writable view with no `unsafe` block at all — but a `string` literal is *interned*, so two unrelated
variables holding `"hunter2"` are the same object, and clearing one corrupts every other holder while
leaving `Length` untouched. The damage is silent until something reads it.

That is only the visible half. The KDF input was encoded from those characters before you could wipe
anything, so a copy has already escaped; wiping the `string` afterwards achieves nothing. This is
also why `SecureString` was not the answer and is documented as not recommended — the plaintext has to
be marshalled out to be used regardless.

There is no supported way to erase a `string`, on any .NET version, and none is planned.

## Characters and bytes carry different things

Both password overloads survive, and they are **not** two spellings of one idea. This is the easiest
thing to get wrong here, because getting it wrong does not throw: it silently derives a different key
and surfaces much later as "the password is incorrect".

| | `ReadOnlySpan<char> password` | `ReadOnlySpan<byte> passwordBytes` |
|---|---|---|
| What it carries | the password **as text** | the KDF input **as bytes** |
| Under PBES2 (what we write) | encoded UTF-8 before use | used verbatim |
| Under PKCS#12 (legacy, read-only) | encoded big-endian UTF-16, NUL-terminated | used verbatim |
| Who chooses the encoding | the scheme in the file | you |

Concretely, for the password `hünter`:

```csharp
char[] text = "hünter".ToCharArray();

// The char overload encodes per scheme. Those six characters become seven bytes
// under PBES2 - ü is two bytes in UTF-8 - and fourteen under the PKCS#12 KDF:
// six big-endian UTF-16 units plus a NUL terminator. You never write either
// encoding yourself; the scheme decides, and that is the point of this overload.
key.ExportEncryptedPkcs8PrivateKey(text, pbe);

// The byte overload does no encoding at all. This *is* the KDF input:
ReadOnlySpan<byte> raw = [0x68, 0xC3, 0xBC, 0x6E, 0x74, 0x65, 0x72];
key.ExportEncryptedPkcs8PrivateKey(raw, pbe);
```

Under **PBES2** — the only scheme this library writes — the character encoding *is* UTF-8, so a `u8`
literal and the equivalent characters derive the same key. That holds for any text, not just ASCII:
`"hünter"u8` and `"hünter".ToCharArray()` open each other's files, and so do emoji. Which is exactly
why the distinction is easy to miss.

They diverge in two cases, both real:

1. **Reading a legacy PKCS#12 file.** Characters become big-endian UTF-16 with a NUL terminator, so
   `"hunter"u8` will not open a file that `"hunter".ToCharArray()` wrote — six bytes against fourteen.
2. **Byte inputs that are not valid UTF-8.** `[0x00, 0xFF, 0x10]` is not the UTF-8 encoding of any
   string, so no character password reaches it. That is what the byte overload is *for*: reproducing
   a derivation input this library would not otherwise produce.

`EncryptedKeyFormatTests.ByteAndCharacterPasswordsAreNotInterchangeable` and
`ErasableMemoryTests.Utf8LiteralAndCharacterPasswordsAgreeUnderPbes2` pin both halves.

Use the `char` overload for anything a human typed. Use the `byte` overload when the derivation input
is what you actually hold.

## What was dropped, and what to use instead

Each row is present on all three key types, so the counts are per type × 3.

### Passwords as `string` — 15 members

| Dropped | Use instead |
|---|---|
| `ImportEncryptedPkcs8PrivateKey(string password, byte[] source)` | `ImportEncryptedPkcs8PrivateKey(ReadOnlySpan<char>, ReadOnlySpan<byte>)` |
| `ExportEncryptedPkcs8PrivateKey(string password, PbeOptions)` | `ExportEncryptedPkcs8PrivateKey(ReadOnlySpan<char>, PbeOptions)` |
| `ExportEncryptedPkcs8PrivateKeyPem(string password, PbeOptions)` | `ExportEncryptedPkcs8PrivateKeyPem(ReadOnlySpan<char>, PbeOptions)` |
| `TryExportEncryptedPkcs8PrivateKey(string password, PbeOptions, Span<byte>, out int)` | `TryExportEncryptedPkcs8PrivateKey(ReadOnlySpan<char>, PbeOptions, Span<byte>, out int)` |
| `ImportFromEncryptedPem(string source, string password)` | `ImportFromEncryptedPem(ReadOnlySpan<char>, ReadOnlySpan<char>)` |

### Plaintext private keys as `string` — 6 members

| Dropped | Use instead |
|---|---|
| `string ExportPkcs8PrivateKeyPem()` | `GetPkcs8PrivateKeyPemSize()` + `TryExportPkcs8PrivateKeyPem(Span<char>, out int)` |
| `ImportFromPem(string source)` | `ImportFromPem(ReadOnlySpan<char>)` |

`ExportPkcs8PrivateKeyPem` is the one member with no signature-compatible replacement, because there
is no way to return a `string` and also let the caller erase it.

### What still returns a `string`

Two members, both because their content is public by construction:

- `ExportSubjectPublicKeyInfoPem()` — a public key.
- `ExportEncryptedPkcs8PrivateKeyPem(...)` — ciphertext. Protecting it is the point of the method.

This is enforced, not merely stated: `ErasableMemoryTests` reflects over the three types on every
target framework and fails if any other public member takes a `string` password or returns a
`string`.

## Sizing the buffer

`TryExportPkcs8PrivateKeyPem` needs a buffer, and guessing is not viable — an ML-DSA-87 expanded-key
PEM runs past 6,700 characters, well beyond the 4,096 most people would reach for. So each type also
carries a size member:

```csharp
int size = key.GetPkcs8PrivateKeyPemSize();          // exact, not an upper bound
int size = key.GetSubjectPublicKeyInfoPemSize();
```

The BCL offers neither. Its own `TryExportPkcs8PrivateKeyPem` leaves you to grow a buffer until it
succeeds, or to reach for `PemEncoding.GetEncodedSize(labelLength, dataLength)` — which needs the DER
length, which you only get by exporting the key first, defeating the purpose. Both size members here
build the encoding to measure it and clear it immediately, costing one extra encode.

**There is deliberately no size member for the encrypted PEM export.** Measuring it means running
PBKDF2, and at a realistic iteration count that is the entire cost of the export — a caller who sized
and then exported would pay it twice. Use the allocating `ExportEncryptedPkcs8PrivateKeyPem`, which
is safe precisely because the payload is ciphertext.

## Migrating

A password moves from a literal to storage you control:

```csharp
// before
byte[] encrypted = key.ExportEncryptedPkcs8PrivateKey("hunter2", pbe);

// after
char[] password = ReadPasswordFromTheUser();   // or stackalloc char[n], or a rented array

try
{
    byte[] encrypted = key.ExportEncryptedPkcs8PrivateKey(password, pbe);
}
finally
{
    Array.Clear(password, 0, password.Length);
}
```

`CryptographicOperations.ZeroMemory` is deliberately not offered for this: this library keeps its copy
internal, and the in-box one takes only a `Span<byte>` — there is no `char` overload on any .NET
version. `Array.Clear` is the portable option. Be aware a compiler may legally elide a store that
nothing reads back; avoiding that is the reason the in-box helper exists at all, and it is a gap on
the character path rather than something this library can close for you.

### When the password genuinely is a constant

`ReadOnlySpan<char>` still accepts `"literal".AsSpan()`, and nothing stops you passing one — what
changed is that the API no longer forces it. If the input really is fixed (a test vector, a key
derivation input you do not control), a UTF-8 literal is the better spelling:

```csharp
ReadOnlySpan<byte> password = "hunter2"u8;
```

It never creates a `String`, which `"hunter2".ToCharArray()` does. Two things it is not: it is still
compiled into the assembly, so it is no more erasable than a literal was; and per the table above it
binds the **byte** overload, so it is the KDF input verbatim rather than text to be encoded.

### The plaintext PEM export

```csharp
int size = key.GetPkcs8PrivateKeyPemSize();
char[] pem = ArrayPool<char>.Shared.Rent(size);

try
{
    if (!key.TryExportPkcs8PrivateKeyPem(pem, out int charsWritten))
    {
        throw new InvalidOperationException("unreachable: the buffer was sized by the key");
    }

    File.WriteAllText(path, new string(pem, 0, charsWritten));   // or write the span directly
}
finally
{
    Array.Clear(pem, 0, size);
    ArrayPool<char>.Shared.Return(pem);
}
```

When the buffer is too small nothing is written and `charsWritten` is zero, matching the `TryExport`
contract used everywhere else on these types.

## Inside the library

The same rule was applied to the implementation, not only the surface:

- `PemFormat` works entirely in spans. The reader returns index ranges into the caller's document
  rather than `Substring` results, so `ImportFromPem(ReadOnlySpan<char>)` no longer materializes the
  document as a string on the way in. The writer emits into the caller's buffer instead of building a
  `StringBuilder`.
- The base64 scratch buffer — the one intermediate that cannot be designed away, since base64 needs
  somewhere to land before it is laid out into 64-character lines — is rented and zeroed.
- `Pkcs8.Read` and `PqcPrivateKeyChoice.Read` must copy their input, because `AsnReader` takes a
  `ReadOnlyMemory<byte>` and a span cannot supply one. Both copies are now cleared in a `finally`.
- `PbePassword` no longer calls `ToArray()` on the password characters on the downlevel targets.

### One residual

`AsnWriter` keeps an internal copy of everything written to it and offers no way to clear it. Its
`Reset()` is documented as resetting the writer *without releasing resources*, and the `IDisposable`
in `System.Formats.Asn1` is `AsnWriter.Scope`, the push/pop helper, not the writer itself. So
`Pkcs8.Write` and the ML-KEM/ML-DSA private-key CHOICE writer leave a plaintext copy of the key in a
buffer this library cannot reach.

Closing it would mean hand-writing the DER for those two structures — a SEQUENCE, an INTEGER, an OID
and an OCTET STRING each. That is deliberately not done here: "no hand-rolled DER" was a founding
constraint of this layer, and these are exactly the two structures a reader would most want produced
by a tested encoder. The exposure is a heap buffer that is never handed out and is overwritten by the
next use of the pooled array. It is recorded here rather than silently accepted.

## Reviewing the removed implementations

The dropped members were not deleted. Each sits under `#if OBSOLETE_SECRET_AS_STRING_API`, with a
comment above the fence — visible whether or not the symbol is defined — naming why it went, so the
unerasable implementation can be diffed against the one that replaced it:

```csharp
    // Dropped from the shipping surface: a string password cannot be overwritten once created.
    // Retained unbuilt for review; see docfx/packages/security/cryptography/erasable-memory.md.
#if OBSOLETE_SECRET_AS_STRING_API
    public static MLDsa ImportEncryptedPkcs8PrivateKey(string password, byte[] source)
#endif
```

No shipping build defines that symbol; opting in is explicit:

```powershell
dotnet build src/Security/Cryptography/Cryptography.csproj -p:EnableObsoleteSecretAsStringApi=true
```

Nothing built that way should be shipped or packed.

## Roadmap

`ReadOnlySpan<char>` is where password overloads land today, and the platform has no better answer to
offer. `SecureString` is documented as not recommended for new development and does not encrypt at
all outside Windows; `System.Text.Utf8String` was prototyped for .NET Core 3.0 and never shipped — the
type does not exist in .NET 10. What .NET settled on is not a holder type at all, but this same pair
of spans, with the caller owning both the storage and the erasure.

A dedicated UTF-8 string type remains the intended destination here — it would make the encoding
explicit rather than implied by the overload chosen, and give a password a type of its own — and will
arrive as an additional overload alongside the spans, not as a replacement for them.

## See Also

- [Signature Algorithms](signature-algorithms.md) — the key-format surface on `MLDsa` and `SlhDsa`
- [KEM Algorithms](kem-algorithms.md) — the same surface on `MLKem`
