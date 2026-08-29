| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 128B         |     161.3 ns |     0.34 ns |     0.28 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128B         |     172.8 ns |     0.63 ns |     0.55 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128B         |     173.8 ns |     1.84 ns |     1.63 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 137B         |     163.4 ns |     2.50 ns |     2.34 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 137B         |     171.6 ns |     0.36 ns |     0.32 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 137B         |     176.3 ns |     2.41 ns |     2.14 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 1KB          |   1,069.5 ns |     7.33 ns |     5.73 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1KB          |   1,081.5 ns |     5.18 ns |     4.32 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1KB          |   1,135.5 ns |     2.92 ns |     2.28 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 1025B        |   1,072.4 ns |     8.27 ns |     7.33 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1025B        |   1,101.9 ns |     5.37 ns |     4.76 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1025B        |   1,152.3 ns |     8.43 ns |     7.89 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 8KB          |   7,540.3 ns |    18.11 ns |    16.05 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 8KB          |   7,582.0 ns |    31.45 ns |    29.42 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 8KB          |   8,044.1 ns |    16.32 ns |    15.26 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128KB        | 120,220.5 ns | 2,035.70 ns | 1,804.60 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 128KB        | 121,258.2 ns |   940.21 ns |   833.47 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128KB        | 127,278.0 ns |   306.36 ns |   286.57 ns |         - |