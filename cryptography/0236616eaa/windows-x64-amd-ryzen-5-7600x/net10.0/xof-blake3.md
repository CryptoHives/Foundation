| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128B         |     1.583 μs | 0.0039 μs | 0.0035 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128B         |     1.697 μs | 0.0010 μs | 0.0009 μs |   9,357 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128B         |     1.859 μs | 0.0029 μs | 0.0023 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128B         |     1.860 μs | 0.0036 μs | 0.0031 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128B         |     1.864 μs | 0.0059 μs | 0.0046 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128B         |     2.185 μs | 0.0068 μs | 0.0060 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128B         |     2.821 μs | 0.0065 μs | 0.0058 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128B         |    19.740 μs | 0.0315 μs | 0.0279 μs |  28,609 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 1KB          |     2.151 μs | 0.0078 μs | 0.0073 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 1KB          |     2.225 μs | 0.0056 μs | 0.0050 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 1KB          |     2.227 μs | 0.0067 μs | 0.0056 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 1KB          |     2.267 μs | 0.0039 μs | 0.0035 μs |   9,600 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 1KB          |     2.504 μs | 0.0122 μs | 0.0108 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 1KB          |     2.795 μs | 0.0053 μs | 0.0045 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 1KB          |     3.741 μs | 0.0119 μs | 0.0106 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 1KB          |    29.431 μs | 0.0261 μs | 0.0218 μs |  28,822 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 8KB          |     3.531 μs | 0.0067 μs | 0.0060 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 8KB          |     3.621 μs | 0.0087 μs | 0.0073 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 8KB          |     6.664 μs | 0.0102 μs | 0.0085 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 8KB          |     6.831 μs | 0.0131 μs | 0.0116 μs |   9,600 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 8KB          |     7.640 μs | 0.0272 μs | 0.0213 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 8KB          |     7.748 μs | 0.0547 μs | 0.0511 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 8KB          |    11.159 μs | 0.0348 μs | 0.0309 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 8KB          |   104.989 μs | 0.1261 μs | 0.1180 μs |  28,580 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128KB        |    23.613 μs | 0.0569 μs | 0.0532 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128KB        |    26.859 μs | 0.0732 μs | 0.0611 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128KB        |    84.075 μs | 0.2115 μs | 0.1766 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128KB        |    85.332 μs | 0.1310 μs | 0.1023 μs |   9,600 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128KB        |    92.457 μs | 0.1691 μs | 0.1582 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128KB        |    95.640 μs | 0.2973 μs | 0.2781 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128KB        |   138.091 μs | 0.4658 μs | 0.3637 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128KB        | 1,318.259 μs | 4.8481 μs | 4.0484 μs |  28,584 B |      56 B |