| Description                                                   | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|-------------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · RIPEMD-160 · BouncyCastle                    | 128B         |     645.2 ns |     1.58 ns |     1.48 ns |         - |
| TryComputeHash · RIPEMD-160 · RIPEMD-160 (CryptoHives-Scalar) | 128B         |     709.8 ns |     3.68 ns |     3.45 ns |         - |
|                                                               |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle                    | 137B         |     642.0 ns |     2.04 ns |     1.91 ns |         - |
| TryComputeHash · RIPEMD-160 · RIPEMD-160 (CryptoHives-Scalar) | 137B         |     709.9 ns |     4.26 ns |     3.55 ns |         - |
|                                                               |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle                    | 1KB          |   3,558.8 ns |    10.27 ns |     9.61 ns |         - |
| TryComputeHash · RIPEMD-160 · RIPEMD-160 (CryptoHives-Scalar) | 1KB          |   3,963.5 ns |    18.64 ns |    15.56 ns |         - |
|                                                               |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle                    | 1025B        |   3,561.5 ns |     7.18 ns |     6.37 ns |         - |
| TryComputeHash · RIPEMD-160 · RIPEMD-160 (CryptoHives-Scalar) | 1025B        |   3,989.0 ns |    34.82 ns |    29.08 ns |         - |
|                                                               |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle                    | 8KB          |  26,841.8 ns |    85.91 ns |    71.74 ns |         - |
| TryComputeHash · RIPEMD-160 · RIPEMD-160 (CryptoHives-Scalar) | 8KB          |  30,041.1 ns |   133.84 ns |   111.76 ns |         - |
|                                                               |              |              |             |             |           |
| TryComputeHash · RIPEMD-160 · BouncyCastle                    | 128KB        | 426,090.8 ns | 1,779.83 ns | 1,486.24 ns |         - |
| TryComputeHash · RIPEMD-160 · RIPEMD-160 (CryptoHives-Scalar) | 128KB        | 475,533.0 ns | 2,189.58 ns | 1,941.01 ns |         - |