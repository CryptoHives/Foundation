| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128B         |     1.582 μs | 0.0075 μs | 0.0070 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128B         |     1.699 μs | 0.0057 μs | 0.0048 μs |   9,505 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128B         |     1.858 μs | 0.0041 μs | 0.0034 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128B         |     1.860 μs | 0.0048 μs | 0.0043 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128B         |     1.862 μs | 0.0073 μs | 0.0068 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128B         |     2.180 μs | 0.0093 μs | 0.0087 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128B         |    10.028 μs | 0.0740 μs | 0.0656 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128B         |    19.903 μs | 0.0911 μs | 0.0852 μs |  28,609 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 1KB          |     2.146 μs | 0.0088 μs | 0.0082 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 1KB          |     2.224 μs | 0.0060 μs | 0.0053 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 1KB          |     2.225 μs | 0.0131 μs | 0.0123 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 1KB          |     2.276 μs | 0.0155 μs | 0.0138 μs |   9,503 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 1KB          |     2.500 μs | 0.0085 μs | 0.0071 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 1KB          |     2.793 μs | 0.0099 μs | 0.0088 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 1KB          |    14.027 μs | 0.0602 μs | 0.0563 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 1KB          |    28.887 μs | 0.1241 μs | 0.1037 μs |  28,827 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 8KB          |     3.411 μs | 0.0166 μs | 0.0139 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 8KB          |     3.550 μs | 0.0098 μs | 0.0087 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 8KB          |     6.655 μs | 0.0170 μs | 0.0142 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 8KB          |     6.845 μs | 0.0193 μs | 0.0181 μs |   9,503 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 8KB          |     7.693 μs | 0.1183 μs | 0.1049 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 8KB          |     7.722 μs | 0.0179 μs | 0.0159 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 8KB          |    46.078 μs | 0.1533 μs | 0.1434 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 8KB          |   102.950 μs | 0.2461 μs | 0.2181 μs |  28,570 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128KB        |    24.054 μs | 0.0685 μs | 0.0640 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128KB        |    26.786 μs | 0.1441 μs | 0.1277 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128KB        |    84.002 μs | 0.2750 μs | 0.2438 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128KB        |    85.212 μs | 0.2015 μs | 0.1885 μs |   9,503 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128KB        |    92.471 μs | 0.2360 μs | 0.2092 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128KB        |    95.547 μs | 0.1719 μs | 0.1608 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128KB        |   594.780 μs | 3.7926 μs | 3.5476 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128KB        | 1,344.358 μs | 4.3761 μs | 4.0935 μs |  28,584 B |      56 B |