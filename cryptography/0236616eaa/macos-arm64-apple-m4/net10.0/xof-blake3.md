| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128B         |     1.647 μs | 0.0005 μs | 0.0004 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128B         |     1.982 μs | 0.0005 μs | 0.0005 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |     1.982 μs | 0.0007 μs | 0.0006 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128B         |     2.090 μs | 0.0004 μs | 0.0003 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128B         |     2.117 μs | 0.0004 μs | 0.0004 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |    12.373 μs | 0.0113 μs | 0.0106 μs |      56 B |
|                                             |              |              |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 1KB          |     2.276 μs | 0.0004 μs | 0.0004 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 1KB          |     2.458 μs | 0.0004 μs | 0.0003 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |     2.731 μs | 0.0003 μs | 0.0002 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 1KB          |     2.845 μs | 0.0004 μs | 0.0003 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 1KB          |     2.861 μs | 0.0006 μs | 0.0005 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |    17.739 μs | 0.0029 μs | 0.0026 μs |      56 B |
|                                             |              |              |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 8KB          |     5.812 μs | 0.0014 μs | 0.0013 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 8KB          |     7.295 μs | 0.0016 μs | 0.0014 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |     9.435 μs | 0.1818 μs | 0.1945 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 8KB          |     9.897 μs | 0.0012 μs | 0.0010 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 8KB          |    10.048 μs | 0.1956 μs | 0.2987 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |    57.315 μs | 0.0320 μs | 0.0267 μs |      56 B |
|                                             |              |              |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128KB        |    67.316 μs | 1.2796 μs | 1.4222 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        |   130.595 μs | 0.5982 μs | 0.5303 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128KB        |   440.354 μs | 0.2071 μs | 0.1729 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128KB        |   527.097 μs | 0.2932 μs | 0.2449 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128KB        |   529.257 μs | 0.3022 μs | 0.2524 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 3,439.195 μs | 3.2267 μs | 2.6945 μs |      56 B |