| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 128B         |     158.8 ns |     0.14 ns |     0.12 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128B         |     171.5 ns |     0.40 ns |     0.38 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128B         |     174.9 ns |     2.20 ns |     2.06 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 137B         |     304.3 ns |     0.38 ns |     0.36 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 137B         |     316.7 ns |     2.98 ns |     2.79 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 137B         |     328.4 ns |     0.25 ns |     0.19 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 1KB          |   1,207.0 ns |     1.29 ns |     1.20 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1KB          |   1,258.9 ns |     6.64 ns |     5.88 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1KB          |   1,292.5 ns |     4.13 ns |     3.86 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 1025B        |   1,330.5 ns |    22.57 ns |    22.17 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1025B        |   1,338.1 ns |    21.73 ns |    23.25 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1025B        |   1,416.6 ns |    11.52 ns |    10.78 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE256 · BouncyCastle       | 8KB          |  10,585.0 ns |   207.06 ns |   283.43 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 8KB          |  11,223.1 ns |   223.30 ns |   313.03 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 8KB          |  11,602.1 ns |   229.81 ns |   568.04 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128KB        | 177,041.0 ns | 3,300.63 ns | 3,087.42 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 128KB        | 182,446.9 ns | 3,390.18 ns | 3,171.18 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128KB        | 186,735.9 ns | 2,322.84 ns | 2,172.79 ns |         - |