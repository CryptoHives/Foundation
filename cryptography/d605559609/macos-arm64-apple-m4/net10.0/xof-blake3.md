| Description                                 | TestDataSize | Mean       | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128B         |   1.648 μs | 0.0005 μs | 0.0004 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128B         |   1.981 μs | 0.0007 μs | 0.0006 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |   1.983 μs | 0.0006 μs | 0.0005 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128B         |   2.089 μs | 0.0006 μs | 0.0006 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128B         |   2.117 μs | 0.0007 μs | 0.0006 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |  12.426 μs | 0.0034 μs | 0.0030 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 1KB          |   2.276 μs | 0.0006 μs | 0.0005 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 1KB          |   2.457 μs | 0.0011 μs | 0.0009 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |   2.729 μs | 0.0008 μs | 0.0006 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 1KB          |   2.860 μs | 0.0013 μs | 0.0012 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 1KB          |  13.501 μs | 0.0983 μs | 0.0871 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |  17.740 μs | 0.0224 μs | 0.0187 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 8KB          |   5.631 μs | 0.0197 μs | 0.0175 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 8KB          |   7.295 μs | 0.0016 μs | 0.0013 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |   8.713 μs | 0.0036 μs | 0.0032 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 8KB          |   8.875 μs | 0.0023 μs | 0.0020 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 8KB          |   8.883 μs | 0.0035 μs | 0.0032 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |  57.236 μs | 0.0321 μs | 0.0268 μs |      56 B |
|                                             |              |            |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Neon   | 128KB        |  63.029 μs | 0.0588 μs | 0.0459 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128KB        |  93.311 μs | 0.0238 μs | 0.0199 μs |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        | 111.260 μs | 0.0314 μs | 0.0279 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128KB        | 125.312 μs | 2.4716 μs | 4.6422 μs |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128KB        | 527.366 μs | 1.3650 μs | 1.2101 μs |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 729.220 μs | 0.2404 μs | 0.2131 μs |      56 B |