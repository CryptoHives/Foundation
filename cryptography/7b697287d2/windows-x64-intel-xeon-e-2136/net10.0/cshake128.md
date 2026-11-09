| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128B         |     335.0 ns |     3.24 ns |     3.03 ns |   5,644 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 128B         |     428.9 ns |     3.64 ns |     3.41 ns |   5,417 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128B         |     465.8 ns |     4.30 ns |     4.03 ns |   7,700 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 137B         |     335.6 ns |     1.22 ns |     1.14 ns |   5,663 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 137B         |     429.6 ns |     3.16 ns |     2.95 ns |   5,417 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 137B         |     465.5 ns |     4.96 ns |     4.64 ns |   7,700 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1KB          |   2,246.9 ns |    25.15 ns |    23.52 ns |   5,626 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 1KB          |   2,839.8 ns |    27.44 ns |    25.66 ns |   5,399 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1KB          |   3,054.1 ns |     9.11 ns |     8.52 ns |   8,291 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1025B        |   2,253.5 ns |    17.91 ns |    16.75 ns |   5,630 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 1025B        |   2,835.6 ns |    27.88 ns |    26.08 ns |   5,401 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1025B        |   3,038.3 ns |    32.13 ns |    30.05 ns |   8,293 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 8KB          |  15,255.6 ns |   122.51 ns |   114.59 ns |   5,632 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 8KB          |  19,725.4 ns |   150.20 ns |   140.50 ns |   5,405 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 8KB          |  21,143.3 ns |   202.88 ns |   189.77 ns |   8,289 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128KB        | 241,695.9 ns | 2,311.71 ns | 2,162.38 ns |   5,626 B |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-AVX2   | 128KB        | 315,174.3 ns | 2,809.00 ns | 2,627.54 ns |   5,424 B |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128KB        | 336,802.2 ns | 3,186.33 ns | 2,980.50 ns |   8,293 B |         - |