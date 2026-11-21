| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 128B         |     162.8 ns |   0.47 ns |   0.44 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128B         |     173.4 ns |   0.60 ns |   0.56 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128B         |     174.5 ns |   0.28 ns |   0.27 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 137B         |     161.7 ns |   0.10 ns |   0.09 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 137B         |     174.2 ns |   0.11 ns |   0.10 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 137B         |     176.0 ns |   0.78 ns |   0.73 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 1KB          |   1,064.3 ns |   2.05 ns |   1.92 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1KB          |   1,091.9 ns |   4.33 ns |   4.05 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1KB          |   1,150.0 ns |   2.14 ns |   2.00 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 1025B        |   1,059.8 ns |   2.91 ns |   2.28 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1025B        |   1,098.4 ns |   9.93 ns |   9.29 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1025B        |   1,146.4 ns |   1.65 ns |   1.54 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 8KB          |   7,337.4 ns |   4.33 ns |   3.84 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 8KB          |   7,531.4 ns |  23.87 ns |  21.16 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 8KB          |   7,937.6 ns |  13.92 ns |  13.02 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 128KB        | 118,781.2 ns | 308.65 ns | 288.71 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128KB        | 120,679.8 ns | 543.66 ns | 481.94 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128KB        | 126,959.8 ns | 456.05 ns | 426.59 ns |         - |