| Description                                         | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 128B         |     91.63 ns |   0.121 ns |   0.113 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128B         |     96.22 ns |   0.149 ns |   0.125 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 137B         |    170.90 ns |   0.099 ns |   0.092 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 137B         |    179.51 ns |   0.307 ns |   0.287 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 1KB          |    664.71 ns |   1.480 ns |   1.384 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1KB          |    695.76 ns |   0.670 ns |   0.627 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 1025B        |    666.05 ns |   1.861 ns |   1.741 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1025B        |    696.04 ns |   1.001 ns |   0.936 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 8KB          |  5,008.16 ns |  14.718 ns |  13.767 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 8KB          |  5,214.06 ns |  10.136 ns |   9.481 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 128KB        | 79,469.35 ns |  98.766 ns |  87.553 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128KB        | 82,357.38 ns | 219.865 ns | 194.904 ns |         - |