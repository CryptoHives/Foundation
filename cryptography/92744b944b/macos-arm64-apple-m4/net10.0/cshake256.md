| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128B         |     178.0 ns |   0.54 ns |   0.45 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128B         |     252.2 ns |   4.37 ns |   3.88 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 137B         |     327.1 ns |   1.07 ns |   0.95 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 137B         |     605.0 ns |   5.58 ns |   4.94 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1KB          |   1,271.7 ns |  16.05 ns |  13.40 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1KB          |   1,473.1 ns |  25.16 ns |  31.82 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1025B        |   1,278.3 ns |  21.17 ns |  19.80 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1025B        |   1,451.4 ns |   9.75 ns |   7.61 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 8KB          |   9,468.9 ns |  48.20 ns |  40.25 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 8KB          |  10,010.8 ns |  40.24 ns |  31.42 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128KB        | 149,997.3 ns | 354.21 ns | 295.78 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128KB        | 154,402.4 ns | 937.27 ns | 782.66 ns |         - |