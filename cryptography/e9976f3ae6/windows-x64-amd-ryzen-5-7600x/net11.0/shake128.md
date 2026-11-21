| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128B         |     255.2 ns |   3.82 ns |   3.57 ns |  16,480 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128B         |     316.6 ns |   0.24 ns |   0.22 ns |  16,454 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128B         |     333.8 ns |   0.20 ns |   0.17 ns |  14,795 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128B         |     376.9 ns |   2.33 ns |   2.18 ns |   8,305 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128B         |     408.9 ns |   0.85 ns |   0.71 ns |  10,737 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 137B         |     245.7 ns |   0.85 ns |   0.66 ns |   9,946 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 137B         |     318.7 ns |   0.20 ns |   0.17 ns |   9,446 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 137B         |     333.7 ns |   0.74 ns |   0.65 ns |   8,469 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 137B         |     375.5 ns |   1.70 ns |   1.42 ns |  14,850 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 137B         |     413.3 ns |   2.34 ns |   1.96 ns |  10,547 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1KB          |   1,631.8 ns |   3.58 ns |   3.18 ns |   9,942 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1KB          |   2,063.3 ns |  16.05 ns |  14.22 ns |  10,547 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1KB          |   2,123.8 ns |   8.81 ns |   8.24 ns |  15,768 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1KB          |   2,197.2 ns |   4.94 ns |   4.62 ns |  14,791 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1KB          |   2,457.4 ns |   3.21 ns |   2.85 ns |  16,534 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 1025B        |   1,636.5 ns |   8.41 ns |   7.86 ns |  16,467 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 1025B        |   2,079.8 ns |  19.94 ns |  16.65 ns |  10,737 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 1025B        |   2,116.5 ns |   4.88 ns |   4.33 ns |   9,442 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 1025B        |   2,195.9 ns |   4.04 ns |   3.58 ns |   8,465 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 1025B        |   2,459.8 ns |  13.24 ns |  11.74 ns |  16,724 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 8KB          |  11,320.4 ns |  16.54 ns |  13.81 ns |  16,286 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 8KB          |  13,599.3 ns |  51.14 ns |  45.33 ns |  10,547 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 8KB          |  14,706.7 ns |   7.37 ns |   6.90 ns |  15,967 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 8KB          |  15,236.9 ns |  29.83 ns |  27.90 ns |   8,465 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 8KB          |  17,155.9 ns | 106.89 ns |  99.99 ns |  10,191 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar  | 128KB        | 180,064.0 ns | 496.85 ns | 464.76 ns |  16,277 B |         - |
| TryComputeHash · SHAKE128 · OS Native           | 128KB        | 214,617.6 ns | 843.39 ns | 747.64 ns |  10,737 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX2    | 128KB        | 233,841.6 ns | 232.65 ns | 217.62 ns |  15,967 B |         - |
| TryComputeHash · SHAKE128 · CryptoHives-AVX512F | 128KB        | 242,762.2 ns | 299.43 ns | 280.09 ns |  14,800 B |         - |
| TryComputeHash · SHAKE128 · BouncyCastle        | 128KB        | 273,588.4 ns | 846.16 ns | 660.62 ns |  16,536 B |         - |