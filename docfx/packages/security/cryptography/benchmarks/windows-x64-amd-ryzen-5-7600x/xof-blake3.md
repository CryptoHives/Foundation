| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128B         |     1.618 μs | 0.0115 μs | 0.0102 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128B         |     1.745 μs | 0.0325 μs | 0.0319 μs |   9,260 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128B         |     1.895 μs | 0.0357 μs | 0.0367 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128B         |     1.900 μs | 0.0313 μs | 0.0278 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128B         |     1.933 μs | 0.0325 μs | 0.0693 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128B         |     2.193 μs | 0.0299 μs | 0.0250 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128B         |    10.262 μs | 0.2019 μs | 0.2074 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128B         |    20.278 μs | 0.3816 μs | 0.3383 μs |  28,609 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 1KB          |     2.176 μs | 0.0365 μs | 0.0305 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 1KB          |     2.256 μs | 0.0262 μs | 0.0245 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 1KB          |     2.264 μs | 0.0373 μs | 0.0349 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 1KB          |     2.290 μs | 0.0134 μs | 0.0104 μs |   9,503 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 1KB          |     2.595 μs | 0.0463 μs | 0.0569 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 1KB          |     2.838 μs | 0.0423 μs | 0.0396 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 1KB          |    14.696 μs | 0.2885 μs | 0.2834 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 1KB          |    29.644 μs | 0.4506 μs | 0.3995 μs |  28,827 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 8KB          |     3.440 μs | 0.0242 μs | 0.0202 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 8KB          |     3.471 μs | 0.0442 μs | 0.0392 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 8KB          |     6.714 μs | 0.0275 μs | 0.0244 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 8KB          |     6.911 μs | 0.0177 μs | 0.0166 μs |   9,503 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 8KB          |     7.778 μs | 0.1204 μs | 0.1067 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 8KB          |     7.803 μs | 0.0433 μs | 0.0362 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 8KB          |    47.165 μs | 0.2443 μs | 0.2166 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 8KB          |   102.283 μs | 0.3844 μs | 0.3407 μs |  28,590 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128KB        |    23.804 μs | 0.0823 μs | 0.0642 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128KB        |    25.280 μs | 0.1199 μs | 0.1063 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128KB        |    84.903 μs | 0.9330 μs | 0.9982 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128KB        |    86.408 μs | 0.3508 μs | 0.3282 μs |   9,503 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128KB        |    92.905 μs | 0.3240 μs | 0.2872 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128KB        |    96.237 μs | 0.4903 μs | 0.4346 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128KB        |   606.887 μs | 2.7564 μs | 2.4435 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128KB        | 1,392.356 μs | 3.6559 μs | 3.4198 μs |  28,594 B |      56 B |