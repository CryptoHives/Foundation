| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 128B         |     161.6 ns |     0.66 ns |     0.62 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128B         |     171.5 ns |     0.68 ns |     0.63 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128B         |     181.0 ns |     1.82 ns |     1.70 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 137B         |     306.3 ns |     0.45 ns |     0.42 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 137B         |     324.0 ns |     2.13 ns |     1.99 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 137B         |     330.8 ns |     0.94 ns |     0.88 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 1KB          |   1,208.5 ns |     5.71 ns |     5.34 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1KB          |   1,271.8 ns |    12.99 ns |    12.15 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1KB          |   1,296.1 ns |     3.98 ns |     3.73 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 1025B        |   1,213.7 ns |     7.42 ns |     6.94 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 1025B        |   1,245.5 ns |     4.24 ns |     3.76 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 1025B        |   1,298.4 ns |     4.48 ns |     4.19 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 8KB          |   9,177.1 ns |    32.41 ns |    30.32 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 8KB          |   9,221.6 ns |    49.73 ns |    44.08 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 8KB          |   9,779.0 ns |    27.49 ns |    25.72 ns |         - |
|                                                |              |              |             |             |           |
| TryComputeHash · SHAKE256 · CryptoHives-Arm64  | 128KB        | 145,466.6 ns |   518.05 ns |   484.59 ns |         - |
| TryComputeHash · SHAKE256 · BouncyCastle       | 128KB        | 146,841.7 ns | 1,641.71 ns | 1,535.66 ns |         - |
| TryComputeHash · SHAKE256 · CryptoHives-Scalar | 128KB        | 154,904.7 ns |   445.11 ns |   416.36 ns |         - |