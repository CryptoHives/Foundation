| Description                                 | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128B         |   1.646 μs | 0.0018 μs | 0.0015 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |   1.693 μs | 0.0026 μs | 0.0024 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128B         |   1.700 μs | 0.0014 μs | 0.0012 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128B         |   1.706 μs | 0.0040 μs | 0.0037 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128B         |   2.102 μs | 0.0038 μs | 0.0036 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |  12.356 μs | 0.0139 μs | 0.0130 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 1KB          |   1.984 μs | 0.0102 μs | 0.0095 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 1KB          |   2.012 μs | 0.0129 μs | 0.0120 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 1KB          |   2.276 μs | 0.0114 μs | 0.0107 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |   2.352 μs | 0.0023 μs | 0.0022 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 1KB          |   2.870 μs | 0.0084 μs | 0.0079 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |  17.492 μs | 0.0750 μs | 0.0701 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 8KB          |   4.652 μs | 0.0210 μs | 0.0196 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 8KB          |   4.744 μs | 0.0214 μs | 0.0200 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 8KB          |   7.316 μs | 0.0189 μs | 0.0177 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |   7.663 μs | 0.0294 μs | 0.0260 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 8KB          |   8.953 μs | 0.0340 μs | 0.0318 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |  56.798 μs | 0.1582 μs | 0.1479 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128KB        |  52.562 μs | 0.1773 μs | 0.1572 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128KB        |  53.367 μs | 0.1909 μs | 0.1786 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128KB        |  93.665 μs | 0.2297 μs | 0.2149 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        |  98.080 μs | 0.5345 μs | 0.5000 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128KB        | 113.162 μs | 0.3270 μs | 0.3059 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 723.040 μs | 2.0743 μs | 1.9403 μs |      56 B |