| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128B         |     1.593 μs | 0.0098 μs | 0.0087 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128B         |     1.703 μs | 0.0035 μs | 0.0031 μs |   9,503 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128B         |     1.888 μs | 0.0120 μs | 0.0112 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128B         |     1.890 μs | 0.0206 μs | 0.0192 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128B         |     1.905 μs | 0.0155 μs | 0.0138 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128B         |     2.196 μs | 0.0220 μs | 0.0205 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128B         |    10.192 μs | 0.0381 μs | 0.0337 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128B         |    20.013 μs | 0.0327 μs | 0.0273 μs |  28,609 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 1KB          |     2.194 μs | 0.0344 μs | 0.0305 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 1KB          |     2.269 μs | 0.0084 μs | 0.0074 μs |   9,503 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 1KB          |     2.275 μs | 0.0286 μs | 0.0239 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 1KB          |     2.290 μs | 0.0216 μs | 0.0202 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 1KB          |     2.558 μs | 0.0355 μs | 0.0296 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 1KB          |     2.853 μs | 0.0313 μs | 0.0262 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 1KB          |    14.170 μs | 0.0311 μs | 0.0276 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 1KB          |    29.917 μs | 0.0481 μs | 0.0401 μs |  28,828 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 8KB          |     3.454 μs | 0.0390 μs | 0.0364 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 8KB          |     3.663 μs | 0.0285 μs | 0.0267 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 8KB          |     6.786 μs | 0.0940 μs | 0.1222 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 8KB          |     6.858 μs | 0.0213 μs | 0.0189 μs |   9,503 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 8KB          |     7.745 μs | 0.0633 μs | 0.0494 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 8KB          |     7.799 μs | 0.0907 μs | 0.0757 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 8KB          |    46.591 μs | 0.1871 μs | 0.1562 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 8KB          |   102.929 μs | 0.1731 μs | 0.1619 μs |  28,590 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128KB        |    27.165 μs | 0.2588 μs | 0.2295 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128KB        |    28.516 μs | 0.2223 μs | 0.1971 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128KB        |    85.640 μs | 0.4006 μs | 0.3748 μs |   9,503 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128KB        |    85.663 μs | 1.0485 μs | 0.9808 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128KB        |    93.801 μs | 1.4180 μs | 1.1841 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128KB        |    97.283 μs | 1.4640 μs | 1.3694 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128KB        |   604.293 μs | 2.6968 μs | 2.3907 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128KB        | 1,352.507 μs | 3.4357 μs | 3.0457 μs |  28,584 B |      56 B |