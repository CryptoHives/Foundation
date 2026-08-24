| Description                                         | TestDataSize | Mean        | Error     | StdDev    | Median      | Allocated |
|---------------------------------------------------- |------------- |------------:|----------:|----------:|------------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 128B         |    117.2 ns |   1.46 ns |   1.36 ns |    117.6 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128B         |    122.4 ns |   1.20 ns |   1.12 ns |    122.4 ns |         - |
|                                                     |              |             |           |           |             |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 137B         |    589.3 ns |  95.65 ns | 282.04 ns |    797.8 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 137B         |    842.9 ns |   2.87 ns |   2.55 ns |    842.5 ns |         - |
|                                                     |              |             |           |           |             |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1KB          |    705.4 ns |  11.26 ns |  14.64 ns |    701.6 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 1KB          |  3,140.9 ns |   9.34 ns |   8.28 ns |  3,141.0 ns |         - |
|                                                     |              |             |           |           |             |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 1025B        |    661.2 ns |   1.39 ns |   1.23 ns |    661.1 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1025B        |    695.9 ns |   1.31 ns |   1.23 ns |    695.9 ns |         - |
|                                                     |              |             |           |           |             |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 8KB          |  5,082.4 ns |   6.05 ns |   5.66 ns |  5,082.0 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 8KB          |  5,224.7 ns |  15.43 ns |  13.67 ns |  5,222.8 ns |         - |
|                                                     |              |             |           |           |             |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 128KB        | 79,898.5 ns |  87.55 ns |  77.61 ns | 79,899.5 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128KB        | 82,418.0 ns | 107.34 ns | 100.41 ns | 82,428.7 ns |         - |