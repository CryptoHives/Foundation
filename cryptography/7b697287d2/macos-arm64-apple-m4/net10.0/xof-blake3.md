| Description                                 | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128B         |   1.641 μs | 0.0047 μs | 0.0044 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |   1.678 μs | 0.0003 μs | 0.0003 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128B         |   1.685 μs | 0.0007 μs | 0.0007 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128B         |   1.695 μs | 0.0066 μs | 0.0062 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128B         |   2.097 μs | 0.0065 μs | 0.0061 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |  12.183 μs | 0.0486 μs | 0.0454 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 1KB          |   1.966 μs | 0.0098 μs | 0.0092 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 1KB          |   1.990 μs | 0.0092 μs | 0.0086 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 1KB          |   2.262 μs | 0.0093 μs | 0.0087 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |   2.342 μs | 0.0068 μs | 0.0063 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 1KB          |   2.855 μs | 0.0061 μs | 0.0057 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |  17.335 μs | 0.0920 μs | 0.0861 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 8KB          |   4.551 μs | 0.0446 μs | 0.0417 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 8KB          |   4.668 μs | 0.0274 μs | 0.0256 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 8KB          |   7.278 μs | 0.0178 μs | 0.0166 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |   7.607 μs | 0.0214 μs | 0.0200 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 8KB          |   8.917 μs | 0.0346 μs | 0.0324 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |  56.093 μs | 0.1996 μs | 0.1769 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128KB        |  51.515 μs | 0.2490 μs | 0.2207 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128KB        |  52.215 μs | 0.2092 μs | 0.1957 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128KB        |  93.215 μs | 0.3321 μs | 0.3106 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        |  97.615 μs | 0.3796 μs | 0.3551 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128KB        | 112.608 μs | 0.3711 μs | 0.3471 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 715.189 μs | 1.9233 μs | 1.7990 μs |      56 B |