| Description                                 | TestDataSize | Mean       | Error      | StdDev     | Allocated |
|-------------------------------------------- |------------- |-----------:|-----------:|-----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128B         |   1.667 μs |  0.0213 μs |  0.0200 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128B         |   1.983 μs |  0.0047 μs |  0.0037 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |   1.985 μs |  0.0021 μs |  0.0017 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128B         |   2.087 μs |  0.0072 μs |  0.0056 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128B         |   2.115 μs |  0.0074 μs |  0.0058 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |  11.810 μs |  0.1585 μs |  0.1324 μs |      56 B |
|                                             |              |            |            |            |           |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 1KB          |   2.284 μs |  0.0028 μs |  0.0022 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 1KB          |   2.481 μs |  0.0429 μs |  0.0401 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |   2.760 μs |  0.0458 μs |  0.0428 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 1KB          |   2.854 μs |  0.0293 μs |  0.0245 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 1KB          |   2.890 μs |  0.0456 μs |  0.0427 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |  16.885 μs |  0.0414 μs |  0.0324 μs |      56 B |
|                                             |              |            |            |            |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 8KB          |   5.773 μs |  0.0833 μs |  0.0738 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 8KB          |   7.393 μs |  0.1012 μs |  0.0947 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |   8.736 μs |  0.0165 μs |  0.0129 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 8KB          |   8.995 μs |  0.1679 μs |  0.1570 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 8KB          |   9.003 μs |  0.1750 μs |  0.1637 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |  55.186 μs |  0.7748 μs |  0.7248 μs |      56 B |
|                                             |              |            |            |            |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128KB        |  62.070 μs |  0.1354 μs |  0.1057 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128KB        |  94.184 μs |  1.2531 μs |  1.1108 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        | 112.490 μs |  1.5444 μs |  1.4446 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128KB        | 112.968 μs |  1.4987 μs |  1.3285 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128KB        | 113.494 μs |  1.3720 μs |  1.2833 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 705.501 μs | 10.9739 μs | 10.2650 μs |      56 B |