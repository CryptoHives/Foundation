| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 128B         |     167.8 ns |   0.49 ns |   0.46 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128B         |     174.5 ns |   0.25 ns |   0.24 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128B         |     177.6 ns |   0.75 ns |   0.70 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 137B         |     167.2 ns |   0.36 ns |   0.34 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 137B         |     176.0 ns |   0.72 ns |   0.67 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 137B         |     177.5 ns |   0.88 ns |   0.78 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 1KB          |   1,063.2 ns |   3.72 ns |   3.48 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1KB          |   1,098.9 ns |   8.34 ns |   7.80 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1KB          |   1,152.2 ns |   3.97 ns |   3.71 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 1025B        |   1,076.6 ns |   4.27 ns |   4.00 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1025B        |   1,105.8 ns |   6.72 ns |   6.28 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1025B        |   1,150.5 ns |   3.28 ns |   3.07 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 8KB          |   7,385.8 ns |  25.71 ns |  24.05 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 8KB          |   7,593.3 ns |  32.76 ns |  30.65 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 8KB          |   7,984.6 ns |  23.33 ns |  21.82 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 128KB        | 118,940.3 ns | 247.81 ns | 231.80 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128KB        | 121,322.6 ns | 426.77 ns | 378.32 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128KB        | 127,256.5 ns | 198.30 ns | 185.49 ns |         - |