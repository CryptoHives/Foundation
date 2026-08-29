| Description                                         | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 128B         |     92.60 ns |   1.225 ns |   1.677 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128B         |     96.98 ns |   0.997 ns |   0.979 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 137B         |    167.69 ns |   0.263 ns |   0.246 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 137B         |    183.27 ns |   0.299 ns |   0.280 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 1KB          |    669.67 ns |   0.837 ns |   0.742 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1KB          |    704.71 ns |   5.340 ns |   4.995 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 1025B        |    673.96 ns |   1.022 ns |   0.956 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1025B        |    697.43 ns |   0.754 ns |   0.629 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 8KB          |  4,969.03 ns |  12.093 ns |  11.312 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 8KB          |  5,225.09 ns |   4.576 ns |   3.572 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 128KB        | 78,621.55 ns | 133.748 ns | 118.564 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128KB        | 82,439.07 ns | 148.275 ns | 138.697 ns |         - |