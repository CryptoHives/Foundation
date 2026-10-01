| Description                                         | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 128B         |     92.01 ns |   0.111 ns |   0.098 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128B         |     96.59 ns |   0.069 ns |   0.057 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 137B         |    167.64 ns |   0.187 ns |   0.166 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 137B         |    179.22 ns |   0.183 ns |   0.171 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 1KB          |    658.36 ns |   0.699 ns |   0.654 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1KB          |    697.82 ns |   0.451 ns |   0.399 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 1025B        |    659.60 ns |   0.582 ns |   0.486 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1025B        |    698.17 ns |   1.564 ns |   1.386 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 8KB          |  4,971.87 ns |   6.622 ns |   6.194 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 8KB          |  5,224.32 ns |   3.506 ns |   3.280 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 128KB        | 78,680.30 ns | 149.319 ns | 132.367 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128KB        | 82,545.25 ns | 221.496 ns | 196.351 ns |         - |