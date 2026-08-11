| Description                                         | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 128B         |     92.00 ns |  0.147 ns |  0.138 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128B         |     96.40 ns |  0.071 ns |  0.063 ns |         - |
|                                                     |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 137B         |    169.89 ns |  0.507 ns |  0.474 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 137B         |    179.05 ns |  0.535 ns |  0.500 ns |         - |
|                                                     |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 1KB          |    665.78 ns |  0.431 ns |  0.403 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1KB          |    694.35 ns |  1.759 ns |  1.645 ns |         - |
|                                                     |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 1025B        |    668.86 ns |  1.824 ns |  1.706 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1025B        |    695.57 ns |  1.105 ns |  1.034 ns |         - |
|                                                     |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 8KB          |  5,017.35 ns |  3.428 ns |  3.038 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 8KB          |  5,216.52 ns |  8.600 ns |  8.044 ns |         - |
|                                                     |              |              |           |           |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 128KB        | 79,559.32 ns | 98.927 ns | 92.537 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128KB        | 82,410.47 ns | 97.175 ns | 86.143 ns |         - |