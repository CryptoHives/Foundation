| Description                                         | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 128B         |     93.56 ns |   0.762 ns |   0.713 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128B         |     99.79 ns |   2.029 ns |   1.898 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 137B         |    169.77 ns |   1.610 ns |   1.257 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 137B         |    183.00 ns |   0.727 ns |   0.568 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 1KB          |    673.88 ns |   1.412 ns |   1.321 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1KB          |    708.80 ns |   7.166 ns |   6.352 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 1025B        |    668.49 ns |   4.526 ns |   4.012 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 1025B        |    705.88 ns |   1.711 ns |   1.517 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 8KB          |  5,068.85 ns |  23.526 ns |  22.006 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 8KB          |  5,283.25 ns |  12.230 ns |  11.440 ns |         - |
|                                                     |              |              |            |            |           |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Arm64  | 128KB        | 79,559.19 ns | 285.087 ns | 266.670 ns |         - |
| TryComputeHash · TurboSHAKE256 · CryptoHives-Scalar | 128KB        | 83,349.24 ns | 252.950 ns | 236.609 ns |         - |