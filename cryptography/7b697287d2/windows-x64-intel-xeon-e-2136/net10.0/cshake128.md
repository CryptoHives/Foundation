| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128B         |     437.4 ns |   0.21 ns |   0.19 ns |   5,663 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 128B         |     549.0 ns |   1.00 ns |   0.93 ns |   5,436 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128B         |     612.9 ns |   0.60 ns |   0.50 ns |   7,710 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 137B         |     438.1 ns |   0.41 ns |   0.39 ns |   5,644 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 137B         |     548.8 ns |   1.32 ns |   1.10 ns |   5,417 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 137B         |     608.7 ns |   0.74 ns |   0.65 ns |   7,700 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1KB          |   2,928.4 ns |   3.48 ns |   2.91 ns |   5,626 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 1KB          |   3,699.5 ns |   6.42 ns |   6.01 ns |   5,399 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1KB          |   3,971.8 ns |   4.03 ns |   3.77 ns |   8,301 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1025B        |   2,933.7 ns |   3.86 ns |   3.42 ns |   5,628 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 1025B        |   3,710.6 ns |   5.78 ns |   5.41 ns |   5,401 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1025B        |   3,972.0 ns |   2.72 ns |   2.54 ns |   8,296 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 8KB          |  19,928.6 ns |  17.79 ns |  16.64 ns |   5,630 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 8KB          |  25,742.1 ns |  35.54 ns |  33.24 ns |   5,403 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 8KB          |  27,560.9 ns |  15.13 ns |  12.63 ns |   8,343 B |         - |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128KB        | 316,199.5 ns | 389.19 ns | 345.01 ns |   5,626 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 128KB        | 409,844.9 ns | 551.88 ns | 489.23 ns |   5,399 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128KB        | 439,900.6 ns | 584.03 ns | 546.31 ns |   8,293 B |         - |