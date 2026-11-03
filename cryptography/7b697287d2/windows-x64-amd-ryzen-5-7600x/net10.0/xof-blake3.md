| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128B         |     1.658 μs | 0.0006 μs | 0.0005 μs |   8,199 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128B         |     1.666 μs | 0.0007 μs | 0.0006 μs |  13,109 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128B         |     1.667 μs | 0.0007 μs | 0.0007 μs |  13,109 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128B         |     1.752 μs | 0.0005 μs | 0.0005 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128B         |     1.826 μs | 0.0008 μs | 0.0007 μs |  20,341 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128B         |     2.410 μs | 0.0006 μs | 0.0005 μs |   6,857 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128B         |     2.838 μs | 0.0029 μs | 0.0027 μs |  16,407 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128B         |    22.513 μs | 0.0269 μs | 0.0251 μs |  28,670 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 1KB          |     1.712 μs | 0.0007 μs | 0.0006 μs |  13,636 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 1KB          |     1.751 μs | 0.0006 μs | 0.0006 μs |  13,089 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 1KB          |     1.876 μs | 0.0005 μs | 0.0005 μs |  20,495 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 1KB          |     2.263 μs | 0.0009 μs | 0.0008 μs |   8,199 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 1KB          |     2.375 μs | 0.0012 μs | 0.0011 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 1KB          |     3.311 μs | 0.0012 μs | 0.0010 μs |   6,857 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 1KB          |     4.130 μs | 0.0056 μs | 0.0050 μs |  16,407 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 1KB          |    33.334 μs | 0.3330 μs | 0.3563 μs |  28,886 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 8KB          |     2.669 μs | 0.0012 μs | 0.0012 μs |  13,636 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 8KB          |     2.703 μs | 0.0014 μs | 0.0013 μs |  20,473 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 8KB          |     3.212 μs | 0.0014 μs | 0.0011 μs |  13,089 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 8KB          |     7.093 μs | 0.0027 μs | 0.0025 μs |   8,201 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 8KB          |     7.379 μs | 0.0021 μs | 0.0019 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 8KB          |     8.568 μs | 0.0090 μs | 0.0079 μs |   6,857 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 8KB          |    13.729 μs | 0.0104 μs | 0.0093 μs |  16,407 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 8KB          |   118.419 μs | 0.1106 μs | 0.1035 μs |  28,638 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128KB        |    17.206 μs | 0.0137 μs | 0.0121 μs |  20,473 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128KB        |    19.315 μs | 0.0094 μs | 0.0083 μs |  13,636 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128KB        |    23.852 μs | 0.0179 μs | 0.0167 μs |  13,089 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128KB        |    89.935 μs | 0.0373 μs | 0.0349 μs |   8,199 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128KB        |    93.135 μs | 0.0291 μs | 0.0272 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128KB        |   102.375 μs | 0.0400 μs | 0.0355 μs |   6,857 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128KB        |   179.027 μs | 0.1634 μs | 0.1449 μs |  16,407 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128KB        | 1,600.664 μs | 2.0670 μs | 1.9335 μs |  28,652 B |      56 B |