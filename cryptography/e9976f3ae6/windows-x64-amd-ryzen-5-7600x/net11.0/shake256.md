| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Median       | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|-------------:|----------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128B         |     244.1 ns |   0.82 ns |   0.73 ns |     243.9 ns |  16,290 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128B         |     315.1 ns |   0.42 ns |   0.39 ns |     315.1 ns |  15,962 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128B         |     332.2 ns |   0.26 ns |   0.23 ns |     332.1 ns |  14,795 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128B         |     374.6 ns |   1.18 ns |   1.05 ns |     374.2 ns |   8,297 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128B         |     417.1 ns |   2.09 ns |   1.85 ns |     416.8 ns |   4,243 B |         - |
|                                                 |              |              |           |           |              |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 137B         |     484.6 ns |   9.13 ns |  21.52 ns |     475.1 ns |  10,125 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 137B         |     642.8 ns |   8.11 ns |   7.59 ns |     642.6 ns |  15,951 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 137B         |     646.4 ns |   0.84 ns |   0.78 ns |     646.3 ns |  14,793 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 137B         |     681.1 ns |   0.76 ns |   0.64 ns |     681.1 ns |   4,243 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 137B         |     718.8 ns |   4.64 ns |   3.62 ns |     717.8 ns |  15,989 B |         - |
|                                                 |              |              |           |           |              |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1KB          |   1,850.9 ns |   9.84 ns |   9.20 ns |   1,847.7 ns |  16,286 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1KB          |   2,404.0 ns |   1.46 ns |   1.29 ns |   2,403.9 ns |  15,967 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1KB          |   2,494.9 ns |   4.93 ns |   4.12 ns |   2,493.5 ns |  14,981 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1KB          |   2,706.4 ns | 126.88 ns | 374.11 ns |   2,598.3 ns |  10,768 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1KB          |   2,824.3 ns |  13.16 ns |  10.99 ns |   2,819.6 ns |  16,128 B |         - |
|                                                 |              |              |           |           |              |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 1025B        |   1,841.1 ns |   6.81 ns |   5.69 ns |   1,840.1 ns |  16,286 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 1025B        |   2,322.2 ns |   8.61 ns |   7.63 ns |   2,322.1 ns |  10,768 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 1025B        |   2,399.2 ns |   1.88 ns |   1.75 ns |   2,398.9 ns |  15,967 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 1025B        |   2,497.6 ns |   3.90 ns |   3.46 ns |   2,495.9 ns |  14,800 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 1025B        |   2,828.8 ns |  10.78 ns |   9.56 ns |   2,827.4 ns |  15,938 B |         - |
|                                                 |              |              |           |           |              |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 8KB          |  13,959.6 ns |  51.92 ns |  43.35 ns |  13,951.4 ns |  16,277 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 8KB          |  16,696.8 ns |  40.75 ns |  36.13 ns |  16,684.9 ns |   4,243 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 8KB          |  18,255.0 ns |  13.67 ns |  12.11 ns |  18,250.3 ns |   9,442 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 8KB          |  18,903.2 ns |  40.37 ns |  37.77 ns |  18,886.8 ns |  14,800 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 8KB          |  21,430.2 ns | 179.45 ns | 159.08 ns |  21,363.7 ns |   9,595 B |         - |
|                                                 |              |              |           |           |              |           |           |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar  | 128KB        | 220,782.0 ns | 796.69 ns | 706.25 ns | 220,533.0 ns |   9,942 B |         - |
| TryComputeHash · SHAKE256 · OS Native           | 128KB        | 263,028.0 ns | 706.37 ns | 551.49 ns | 263,008.8 ns |  10,578 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX2    | 128KB        | 286,875.6 ns | 234.89 ns | 219.72 ns | 286,876.8 ns |  15,768 B |         - |
| TryComputeHash · SHAKE256 · CryptoHives-AVX512F | 128KB        | 298,378.0 ns | 165.50 ns | 146.71 ns | 298,363.1 ns |  14,791 B |         - |
| TryComputeHash · SHAKE256 · BouncyCastle        | 128KB        | 338,282.8 ns | 817.53 ns | 724.72 ns | 338,262.8 ns |  16,130 B |         - |