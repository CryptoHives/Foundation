| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 128B         |     2.169 μs | 0.0033 μs | 0.0031 μs |  16,909 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2   | 128B         |     2.236 μs | 0.0037 μs | 0.0035 μs |  17,094 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128B         |     2.238 μs | 0.0005 μs | 0.0005 μs |     973 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128B         |     2.452 μs | 0.0038 μs | 0.0035 μs |  35,902 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128B         |     3.134 μs | 0.0026 μs | 0.0022 μs |  15,650 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128B         |     4.162 μs | 0.0277 μs | 0.0259 μs |  24,888 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128B         |    22.092 μs | 0.0128 μs | 0.0114 μs |  27,255 B |      56 B |
|                                             |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2   | 1KB          |     2.422 μs | 0.0020 μs | 0.0017 μs |  23,429 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 1KB          |     2.660 μs | 0.0083 μs | 0.0077 μs |  35,620 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 1KB          |     3.009 μs | 0.0007 μs | 0.0006 μs |  17,099 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 1KB          |     3.134 μs | 0.0013 μs | 0.0012 μs |     973 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 1KB          |     4.144 μs | 0.0016 μs | 0.0015 μs |  15,699 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 1KB          |     5.883 μs | 0.0290 μs | 0.0272 μs |  25,078 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 1KB          |    33.228 μs | 0.0084 μs | 0.0079 μs |  33,582 B |      56 B |
|                                             |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2   | 8KB          |     5.060 μs | 0.0011 μs | 0.0009 μs |  23,429 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 8KB          |     5.471 μs | 0.0213 μs | 0.0199 μs |  29,285 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 8KB          |     9.893 μs | 0.0139 μs | 0.0130 μs |  16,909 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 8KB          |    10.262 μs | 0.0054 μs | 0.0050 μs |     973 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 8KB          |    12.297 μs | 0.0068 μs | 0.0064 μs |  15,899 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 8KB          |    19.051 μs | 0.0251 μs | 0.0234 μs |  18,553 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 8KB          |   109.637 μs | 0.0470 μs | 0.0440 μs |  33,637 B |      56 B |
|                                             |              |              |           |           |           |           |
| AbsorbSqueeze · BLAKE3 · CryptoHives-AVX2   | 128KB        |    51.562 μs | 0.2938 μs | 0.2748 μs |  23,619 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.Managed     | 128KB        |    55.210 μs | 0.3964 μs | 0.3708 μs |  35,620 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Ssse3  | 128KB        |   126.670 μs | 0.2964 μs | 0.2772 μs |  16,909 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Native  | 128KB        |   132.766 μs | 0.1369 μs | 0.1280 μs |     973 B |         - |
| AbsorbSqueeze · BLAKE3 · Blake3.NET-Managed | 128KB        |   151.969 μs | 0.2538 μs | 0.2374 μs |  15,873 B |         - |
| AbsorbSqueeze · BLAKE3 · CryptoHives-Scalar | 128KB        |   244.408 μs | 0.4394 μs | 0.4111 μs |  24,888 B |         - |
| AbsorbSqueeze · BLAKE3 · BouncyCastle       | 128KB        | 1,449.273 μs | 0.4951 μs | 0.4134 μs |  27,488 B |      56 B |