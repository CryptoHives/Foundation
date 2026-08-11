| Description                                     | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 128B         |     161.5 ns |     2.81 ns |     2.49 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128B         |     172.7 ns |     2.82 ns |     2.64 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128B         |     173.4 ns |     2.83 ns |     2.65 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 137B         |     306.3 ns |     5.71 ns |     5.34 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 137B         |     318.4 ns |     5.84 ns |     5.46 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 137B         |     329.0 ns |     5.35 ns |     4.74 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 1KB          |   1,221.0 ns |    23.67 ns |    20.98 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1KB          |   1,232.7 ns |     4.15 ns |     3.24 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1KB          |   1,293.1 ns |    20.10 ns |    17.82 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 1025B        |   1,205.9 ns |     2.30 ns |     1.79 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 1025B        |   1,233.4 ns |    14.92 ns |    12.46 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 1025B        |   1,301.4 ns |    20.11 ns |    18.81 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 8KB          |   9,212.1 ns |    51.67 ns |    40.34 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 8KB          |   9,248.4 ns |     4.79 ns |     3.74 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 8KB          |   9,711.8 ns |    35.31 ns |    27.57 ns |         - |
|                                                 |              |              |             |             |           |
| TryComputeHash · cSHAKE256 · CryptoHives-Arm64  | 128KB        | 145,259.3 ns |   305.69 ns |   238.66 ns |         - |
| TryComputeHash · cSHAKE256 · BouncyCastle       | 128KB        | 148,287.7 ns | 2,816.08 ns | 2,765.76 ns |         - |
| TryComputeHash · cSHAKE256 · CryptoHives-Scalar | 128KB        | 155,104.8 ns | 2,723.70 ns | 2,547.75 ns |         - |