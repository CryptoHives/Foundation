| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128B         |     333.6 ns |     3.26 ns |     3.05 ns |   5,639 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 128B         |     426.2 ns |     4.02 ns |     3.76 ns |   5,412 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128B         |     472.5 ns |     5.54 ns |     5.18 ns |   7,701 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 137B         |     643.0 ns |     7.06 ns |     6.61 ns |   5,622 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 137B         |     821.1 ns |     9.26 ns |     8.66 ns |   5,395 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 137B         |     883.5 ns |     6.26 ns |     5.85 ns |   8,973 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1KB          |   2,558.9 ns |    20.33 ns |    19.02 ns |   5,647 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 1KB          |   3,229.1 ns |    29.75 ns |    27.83 ns |   5,400 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1KB          |   3,429.1 ns |    32.90 ns |    30.78 ns |   8,951 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1025B        |   2,550.4 ns |    25.51 ns |    23.86 ns |   5,627 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 1025B        |   3,226.2 ns |    24.33 ns |    22.76 ns |   5,400 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1025B        |   3,427.7 ns |    32.12 ns |    30.04 ns |   8,951 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 8KB          |  18,943.8 ns |    75.51 ns |    70.63 ns |   5,626 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 8KB          |  24,430.4 ns |   214.65 ns |   200.78 ns |   5,397 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 8KB          |  25,749.2 ns |   273.00 ns |   255.36 ns |   8,941 B |         - |
|                                                 |              |              |             |             |           |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128KB        | 296,460.6 ns | 2,549.80 ns | 2,385.09 ns |   5,625 B |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-AVX2   | 128KB        | 386,296.6 ns | 3,765.18 ns | 3,521.96 ns |   5,398 B |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128KB        | 406,095.9 ns | 3,412.48 ns | 3,192.04 ns |   8,945 B |         - |