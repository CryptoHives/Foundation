| Description                                 | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128B         |   1.655 μs | 0.0048 μs | 0.0042 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |   1.992 μs | 0.0014 μs | 0.0013 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128B         |   2.091 μs | 0.0043 μs | 0.0040 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128B         |   2.119 μs | 0.0052 μs | 0.0049 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128B         |   3.825 μs | 0.0345 μs | 0.0323 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |  11.792 μs | 0.0220 μs | 0.0205 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 1KB          |   2.287 μs | 0.0060 μs | 0.0053 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |   2.747 μs | 0.0038 μs | 0.0032 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 1KB          |   2.847 μs | 0.0098 μs | 0.0091 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 1KB          |   2.866 μs | 0.0096 μs | 0.0090 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 1KB          |   4.346 μs | 0.0165 μs | 0.0138 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |  16.948 μs | 0.0098 μs | 0.0091 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 8KB          |   7.293 μs | 0.0033 μs | 0.0030 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 8KB          |   7.680 μs | 0.0546 μs | 0.0511 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |   8.744 μs | 0.0251 μs | 0.0234 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 8KB          |   8.853 μs | 0.0029 μs | 0.0027 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 8KB          |   8.867 μs | 0.0129 μs | 0.0115 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |  54.509 μs | 0.0098 μs | 0.0091 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128KB        |  64.033 μs | 0.2275 μs | 0.2128 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128KB        |  93.307 μs | 0.0199 μs | 0.0187 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        | 111.018 μs | 0.1038 μs | 0.0971 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128KB        | 112.457 μs | 0.0851 μs | 0.0796 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128KB        | 112.635 μs | 0.3741 μs | 0.3499 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 695.282 μs | 0.2104 μs | 0.1865 μs |      56 B |