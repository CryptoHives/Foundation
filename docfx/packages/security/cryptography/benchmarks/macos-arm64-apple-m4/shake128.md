| Description                                    | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|----------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 128B         |     161.0 ns |   0.13 ns |   0.12 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128B         |     170.6 ns |   0.11 ns |   0.09 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128B         |     179.9 ns |   0.73 ns |   0.65 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 137B         |     162.9 ns |   0.21 ns |   0.18 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 137B         |     171.2 ns |   0.16 ns |   0.13 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 137B         |     179.4 ns |   0.67 ns |   0.60 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 1KB          |   1,061.3 ns |   0.75 ns |   0.70 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1KB          |   1,112.9 ns |   1.91 ns |   1.60 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1KB          |   1,127.8 ns |   2.15 ns |   1.90 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 1025B        |   1,050.3 ns |   1.16 ns |   1.09 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 1025B        |   1,117.0 ns |   3.45 ns |   3.06 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 1025B        |   1,130.8 ns |   1.59 ns |   1.49 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 8KB          |   7,358.6 ns |   4.52 ns |   4.01 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 8KB          |   7,668.5 ns |  22.33 ns |  20.88 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 8KB          |   7,824.4 ns |  14.62 ns |  12.96 ns |         - |
|                                                |              |              |           |           |           |
| TryComputeHash · SHAKE128 · CryptoHives-Arm64  | 128KB        | 116,944.0 ns | 112.88 ns | 105.59 ns |         - |
| TryComputeHash · SHAKE128 · BouncyCastle       | 128KB        | 123,433.1 ns | 821.64 ns | 768.56 ns |         - |
| TryComputeHash · SHAKE128 · CryptoHives-Scalar | 128KB        | 124,387.7 ns | 171.74 ns | 134.08 ns |         - |