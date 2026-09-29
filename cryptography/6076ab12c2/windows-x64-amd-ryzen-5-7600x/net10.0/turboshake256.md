| Description                                          | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|----------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128B         |     139.5 ns |   0.31 ns |   0.29 ns |   5,587 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128B         |     177.7 ns |   0.15 ns |   0.14 ns |   5,099 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128B         |     179.3 ns |   0.19 ns |   0.18 ns |   4,094 B |         - |
|                                                      |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 137B         |     259.3 ns |   0.81 ns |   0.76 ns |   5,565 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 137B         |     338.3 ns |   0.34 ns |   0.30 ns |   5,074 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 137B         |     341.1 ns |   0.29 ns |   0.27 ns |   4,073 B |         - |
|                                                      |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1KB          |     989.9 ns |   3.83 ns |   3.58 ns |   5,577 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1KB          |   1,254.0 ns |   1.14 ns |   1.06 ns |   5,087 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1KB          |   1,302.0 ns |   1.00 ns |   0.88 ns |   4,077 B |         - |
|                                                      |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 1025B        |     995.2 ns |   6.20 ns |   5.80 ns |   5,573 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 1025B        |   1,272.5 ns |   7.44 ns |   6.21 ns |   5,082 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 1025B        |   1,301.2 ns |   0.61 ns |   0.57 ns |   4,081 B |         - |
|                                                      |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 8KB          |   7,493.4 ns |  12.86 ns |  11.40 ns |   5,572 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 8KB          |   9,471.8 ns |  20.15 ns |  18.85 ns |   5,081 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 8KB          |   9,839.3 ns |  19.11 ns |  17.87 ns |   4,076 B |         - |
|                                                      |              |              |           |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar  | 128KB        | 118,125.6 ns | 196.40 ns | 174.11 ns |   5,571 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX2    | 128KB        | 149,674.7 ns | 397.62 ns | 371.93 ns |   5,080 B |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-AVX512F | 128KB        | 155,247.4 ns | 303.54 ns | 283.93 ns |   4,075 B |         - |