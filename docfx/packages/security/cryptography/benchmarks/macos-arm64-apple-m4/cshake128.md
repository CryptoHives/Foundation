| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 128B         |     159.5 ns |   0.81 ns |   0.63 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128B         |     169.5 ns |   0.38 ns |   0.30 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128B         |     180.5 ns |   0.53 ns |   0.42 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 137B         |     158.8 ns |   0.67 ns |   0.60 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 137B         |     171.0 ns |   0.32 ns |   0.27 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 137B         |     180.9 ns |   0.81 ns |   0.63 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 1KB          |   1,086.2 ns |   0.90 ns |   0.84 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1KB          |   1,127.3 ns |   2.13 ns |   1.89 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1KB          |   1,131.8 ns |   1.66 ns |   1.47 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 1025B        |   1,065.1 ns |   1.30 ns |   1.09 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 1025B        |   1,119.0 ns |   1.54 ns |   1.20 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 1025B        |   1,134.8 ns |   1.63 ns |   1.44 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 8KB          |   7,377.3 ns |  28.78 ns |  22.47 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 8KB          |   7,719.5 ns |  51.91 ns |  46.02 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 8KB          |   7,849.9 ns |  12.06 ns |   9.41 ns |         - |
|                                                 |              |              |           |           |           |
| TryComputeHash · cSHAKE128 · CryptoHives-Arm64  | 128KB        | 119,435.1 ns |  76.29 ns |  63.70 ns |         - |
| TryComputeHash · cSHAKE128 · BouncyCastle       | 128KB        | 123,304.5 ns | 493.69 ns | 437.64 ns |         - |
| TryComputeHash · cSHAKE128 · CryptoHives-Scalar | 128KB        | 124,918.5 ns | 313.34 ns | 277.77 ns |         - |