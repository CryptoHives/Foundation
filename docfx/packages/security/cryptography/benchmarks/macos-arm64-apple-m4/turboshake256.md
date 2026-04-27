| Description                                         | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 128B         |     89.83 ns |   0.108 ns |   0.084 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128B         |     94.40 ns |   0.179 ns |   0.159 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 137B         |    171.44 ns |   0.951 ns |   0.742 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 137B         |    178.63 ns |   0.420 ns |   0.328 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 1KB          |    669.07 ns |   1.584 ns |   1.237 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1KB          |    696.55 ns |   1.939 ns |   1.719 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 1025B        |    670.40 ns |   1.788 ns |   1.493 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1025B        |    692.86 ns |   0.863 ns |   0.721 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 8KB          |  5,036.00 ns |  14.722 ns |  13.051 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 8KB          |  5,205.14 ns |  19.761 ns |  18.485 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 128KB        | 80,726.10 ns | 743.523 ns | 620.875 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128KB        | 82,358.96 ns | 377.127 ns | 294.436 ns |         - |