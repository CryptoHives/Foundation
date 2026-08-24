| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 128B         |     190.5 ns |     3.84 ns |    10.44 ns |     193.8 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128B         |     199.9 ns |     3.33 ns |     2.60 ns |     200.9 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128B         |     205.4 ns |     4.07 ns |     5.83 ns |     204.7 ns |         - |
|                                                |              |              |             |             |              |           |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 137B         |     207.5 ns |     4.09 ns |     6.25 ns |     208.6 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 137B         |     207.9 ns |     3.51 ns |     3.11 ns |     208.3 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 137B         |     208.6 ns |     2.94 ns |     2.75 ns |     208.7 ns |         - |
|                                                |              |              |             |             |              |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 1KB          |   5,017.0 ns |    10.94 ns |     9.13 ns |   5,019.7 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1KB          |   5,077.6 ns |     8.07 ns |     6.30 ns |   5,075.3 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1KB          |   5,363.6 ns |     9.29 ns |     8.69 ns |   5,362.6 ns |         - |
|                                                |              |              |             |             |              |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 1025B        |   5,000.9 ns |    21.89 ns |    20.48 ns |   5,008.7 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1025B        |   5,075.7 ns |     3.57 ns |     2.98 ns |   5,075.4 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1025B        |   5,352.0 ns |    23.28 ns |    21.77 ns |   5,346.2 ns |         - |
|                                                |              |              |             |             |              |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 8KB          |  34,630.6 ns |   106.14 ns |    88.63 ns |  34,612.7 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 8KB          |  35,144.6 ns |   275.77 ns |   244.47 ns |  35,015.4 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 8KB          |  37,170.1 ns |   103.21 ns |    91.50 ns |  37,134.3 ns |         - |
|                                                |              |              |             |             |              |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 128KB        | 559,264.9 ns | 1,012.25 ns |   897.33 ns | 559,175.9 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128KB        | 559,542.2 ns | 3,479.30 ns | 2,905.37 ns | 558,655.4 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128KB        | 593,277.7 ns | 4,390.58 ns | 3,892.14 ns | 593,027.0 ns |         - |