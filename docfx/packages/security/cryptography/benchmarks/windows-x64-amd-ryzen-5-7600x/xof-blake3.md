| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Median       | Code Size | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|-------------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128B         |     1.642 μs | 0.0295 μs | 0.0261 μs |     1.645 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128B         |     1.790 μs | 0.0357 μs | 0.0761 μs |     1.780 μs |   9,503 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128B         |     1.862 μs | 0.0071 μs | 0.0066 μs |     1.859 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128B         |     1.863 μs | 0.0064 μs | 0.0057 μs |     1.861 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128B         |     1.869 μs | 0.0067 μs | 0.0060 μs |     1.869 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128B         |     2.212 μs | 0.0441 μs | 0.0490 μs |     2.220 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128B         |    10.089 μs | 0.0532 μs | 0.0497 μs |    10.062 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128B         |    19.981 μs | 0.1540 μs | 0.1365 μs |    19.969 μs |  28,612 B |      56 B |
|                                              |              |              |           |           |              |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 1KB          |     2.174 μs | 0.0253 μs | 0.0570 μs |     2.158 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 1KB          |     2.224 μs | 0.0098 μs | 0.0092 μs |     2.223 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 1KB          |     2.224 μs | 0.0095 μs | 0.0079 μs |     2.225 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 1KB          |     2.283 μs | 0.0059 μs | 0.0055 μs |     2.282 μs |   9,503 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 1KB          |     2.611 μs | 0.0531 μs | 0.1548 μs |     2.517 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 1KB          |     2.784 μs | 0.0102 μs | 0.0091 μs |     2.785 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 1KB          |    14.597 μs | 0.2797 μs | 0.2873 μs |    14.592 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 1KB          |    29.631 μs | 0.1388 μs | 0.1298 μs |    29.598 μs |  28,831 B |      56 B |
|                                              |              |              |           |           |              |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 8KB          |     3.408 μs | 0.0146 μs | 0.0122 μs |     3.411 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 8KB          |     3.423 μs | 0.0168 μs | 0.0140 μs |     3.423 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 8KB          |     6.675 μs | 0.0132 μs | 0.0117 μs |     6.674 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 8KB          |     6.826 μs | 0.0134 μs | 0.0112 μs |     6.825 μs |   9,503 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 8KB          |     7.641 μs | 0.0230 μs | 0.0204 μs |     7.636 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 8KB          |     7.739 μs | 0.0312 μs | 0.0292 μs |     7.737 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 8KB          |    46.217 μs | 0.3469 μs | 0.3245 μs |    46.139 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 8KB          |   103.406 μs | 0.3331 μs | 0.3116 μs |   103.353 μs |  28,590 B |      56 B |
|                                              |              |              |           |           |              |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128KB        |    23.730 μs | 0.0967 μs | 0.0904 μs |    23.718 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128KB        |    26.143 μs | 0.0919 μs | 0.0814 μs |    26.131 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128KB        |    84.266 μs | 0.3745 μs | 0.3320 μs |    84.244 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128KB        |    85.406 μs | 0.4184 μs | 0.3914 μs |    85.520 μs |   9,503 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128KB        |    92.602 μs | 0.3635 μs | 0.3035 μs |    92.548 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128KB        |    95.742 μs | 0.3089 μs | 0.2738 μs |    95.741 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128KB        |   598.446 μs | 2.3013 μs | 2.0401 μs |   598.402 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128KB        | 1,336.272 μs | 8.1400 μs | 7.2159 μs | 1,333.719 μs |  28,594 B |      56 B |