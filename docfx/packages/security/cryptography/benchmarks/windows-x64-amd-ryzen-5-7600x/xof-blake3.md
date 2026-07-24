| Description                                  | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|--------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128B         |     1.595 μs | 0.0170 μs | 0.0151 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128B         |     1.702 μs | 0.0025 μs | 0.0022 μs |   9,503 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128B         |     1.883 μs | 0.0129 μs | 0.0121 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128B         |     1.889 μs | 0.0241 μs | 0.0201 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128B         |     1.908 μs | 0.0135 μs | 0.0126 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128B         |     2.189 μs | 0.0213 μs | 0.0199 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128B         |    10.147 μs | 0.0267 μs | 0.0236 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128B         |    20.445 μs | 0.0387 μs | 0.0343 μs |  28,609 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 1KB          |     2.168 μs | 0.0308 μs | 0.0257 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 1KB          |     2.242 μs | 0.0219 μs | 0.0205 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 1KB          |     2.275 μs | 0.0056 μs | 0.0052 μs |   9,503 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 1KB          |     2.275 μs | 0.0262 μs | 0.0245 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 1KB          |     2.533 μs | 0.0271 μs | 0.0254 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 1KB          |     2.814 μs | 0.0226 μs | 0.0211 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 1KB          |    14.223 μs | 0.0730 μs | 0.0683 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 1KB          |    29.162 μs | 0.0354 μs | 0.0296 μs |  28,822 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 8KB          |     3.441 μs | 0.0389 μs | 0.0345 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 8KB          |     3.443 μs | 0.0270 μs | 0.0252 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 8KB          |     6.718 μs | 0.0473 μs | 0.0443 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 8KB          |     6.862 μs | 0.0197 μs | 0.0185 μs |   9,503 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 8KB          |     7.699 μs | 0.0567 μs | 0.0531 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 8KB          |     7.818 μs | 0.1345 μs | 0.1192 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 8KB          |    46.538 μs | 0.1048 μs | 0.0875 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 8KB          |   100.799 μs | 0.3058 μs | 0.2553 μs |  28,590 B |      56 B |
|                                              |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX512F | 128KB        |    23.876 μs | 0.1906 μs | 0.1690 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2    | 128KB        |    24.342 μs | 0.2157 μs | 0.2018 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native   | 128KB        |    84.897 μs | 0.9819 μs | 0.9185 μs |     976 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed      | 128KB        |    85.660 μs | 0.2905 μs | 0.2575 μs |   9,503 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed  | 128KB        |    93.268 μs | 1.0350 μs | 0.8643 μs |   6,627 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3   | 128KB        |    96.548 μs | 0.7115 μs | 0.6655 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar  | 128KB        |   601.683 μs | 1.3787 μs | 1.2222 μs |        NA |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle        | 128KB        | 1,367.916 μs | 2.9567 μs | 2.4690 μs |  28,584 B |      56 B |