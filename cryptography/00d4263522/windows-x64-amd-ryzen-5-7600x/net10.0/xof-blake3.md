| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128B         |     1.589 μs | 0.0040 μs | 0.0034 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128B         |     1.732 μs | 0.0022 μs | 0.0020 μs |   9,600 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128B         |     1.872 μs | 0.0042 μs | 0.0037 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128B         |     1.886 μs | 0.0148 μs | 0.0124 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128B         |     1.891 μs | 0.0046 μs | 0.0038 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128B         |     2.179 μs | 0.0055 μs | 0.0049 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128B         |     2.876 μs | 0.0122 μs | 0.0115 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128B         |    20.426 μs | 0.0383 μs | 0.0359 μs |  28,596 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 1KB          |     2.155 μs | 0.0095 μs | 0.0085 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 1KB          |     2.251 μs | 0.0077 μs | 0.0069 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 1KB          |     2.255 μs | 0.0128 μs | 0.0114 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 1KB          |     2.314 μs | 0.0064 μs | 0.0060 μs |   9,600 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 1KB          |     2.517 μs | 0.0126 μs | 0.0118 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 1KB          |     2.806 μs | 0.0120 μs | 0.0112 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 1KB          |     3.813 μs | 0.0094 μs | 0.0083 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 1KB          |    29.709 μs | 0.0518 μs | 0.0433 μs |  28,822 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 8KB          |     3.446 μs | 0.0099 μs | 0.0088 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 8KB          |     3.572 μs | 0.0126 μs | 0.0105 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 8KB          |     6.678 μs | 0.0125 μs | 0.0117 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 8KB          |     6.972 μs | 0.0133 μs | 0.0118 μs |   9,600 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 8KB          |     7.671 μs | 0.0297 μs | 0.0264 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 8KB          |     7.750 μs | 0.0216 μs | 0.0169 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 8KB          |    11.301 μs | 0.0228 μs | 0.0190 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 8KB          |   106.969 μs | 0.2525 μs | 0.2239 μs |  28,590 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128KB        |    23.750 μs | 0.0645 μs | 0.0539 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128KB        |    23.869 μs | 0.0495 μs | 0.0414 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128KB        |    84.544 μs | 0.4909 μs | 0.4099 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128KB        |    86.773 μs | 0.1356 μs | 0.1202 μs |   9,600 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128KB        |    92.781 μs | 0.3809 μs | 0.3377 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128KB        |    95.912 μs | 0.2617 μs | 0.2320 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128KB        |   140.612 μs | 0.6973 μs | 0.6181 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128KB        | 1,444.748 μs | 1.6013 μs | 1.3371 μs |  28,584 B |      56 B |