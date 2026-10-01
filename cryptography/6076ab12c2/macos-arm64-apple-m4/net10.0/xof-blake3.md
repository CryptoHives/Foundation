| Description                                 | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128B         |   1.649 μs | 0.0004 μs | 0.0004 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |   1.702 μs | 0.0006 μs | 0.0005 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128B         |   1.710 μs | 0.0007 μs | 0.0006 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128B         |   1.713 μs | 0.0006 μs | 0.0006 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128B         |   2.089 μs | 0.0005 μs | 0.0005 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |  12.621 μs | 0.0033 μs | 0.0029 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 1KB          |   1.991 μs | 0.0062 μs | 0.0058 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 1KB          |   2.274 μs | 0.0015 μs | 0.0014 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |   2.334 μs | 0.0006 μs | 0.0005 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 1KB          |   2.352 μs | 0.0031 μs | 0.0029 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 1KB          |   2.845 μs | 0.0007 μs | 0.0007 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |  17.510 μs | 0.0693 μs | 0.0648 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 8KB          |   4.704 μs | 0.0190 μs | 0.0178 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 8KB          |   7.287 μs | 0.0050 μs | 0.0047 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 8KB          |   7.533 μs | 0.0035 μs | 0.0031 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |   7.575 μs | 0.0040 μs | 0.0035 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 8KB          |   8.873 μs | 0.0036 μs | 0.0032 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |  56.587 μs | 0.1284 μs | 0.1201 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128KB        |  52.451 μs | 0.1996 μs | 0.1770 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128KB        |  93.170 μs | 0.0777 μs | 0.0727 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128KB        |  96.162 μs | 0.0646 μs | 0.0604 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        |  97.461 μs | 0.0637 μs | 0.0595 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128KB        | 112.132 μs | 0.0300 μs | 0.0281 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 716.304 μs | 2.3495 μs | 2.0828 μs |      56 B |