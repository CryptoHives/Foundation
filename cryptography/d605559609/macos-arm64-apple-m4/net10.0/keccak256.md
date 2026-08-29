| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Median       | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|-------------:|----------:|
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 128B         |     188.6 ns |     3.73 ns |     6.23 ns |     190.0 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128B         |     205.7 ns |     3.04 ns |     2.84 ns |     206.9 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128B         |     391.7 ns |    97.47 ns |   287.39 ns |     211.1 ns |         - |
|                                                  |              |              |             |             |              |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 137B         |     303.9 ns |     2.11 ns |     1.65 ns |     302.9 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 137B         |     317.9 ns |     4.72 ns |     4.18 ns |     316.1 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 137B         |     325.7 ns |     0.68 ns |     0.57 ns |     325.8 ns |         - |
|                                                  |              |              |             |             |              |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 1KB          |   1,199.1 ns |     1.91 ns |     1.70 ns |   1,198.7 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1KB          |   1,229.3 ns |     5.09 ns |     4.25 ns |   1,228.2 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1KB          |   1,290.5 ns |     2.71 ns |     2.41 ns |   1,290.0 ns |         - |
|                                                  |              |              |             |             |              |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 1025B        |   1,201.3 ns |     1.67 ns |     1.48 ns |   1,201.2 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 1025B        |   1,233.4 ns |     7.73 ns |     6.85 ns |   1,230.9 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 1025B        |   1,290.4 ns |     2.86 ns |     2.68 ns |   1,289.1 ns |         - |
|                                                  |              |              |             |             |              |           |
| TryComputeHash · Keccak-256 · BouncyCastle       | 8KB          |  10,609.8 ns |   208.99 ns |   360.49 ns |  10,689.2 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 8KB          |  10,684.9 ns |   200.89 ns |   346.53 ns |  10,765.8 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 8KB          |  11,256.4 ns |   206.30 ns |   182.88 ns |  11,286.4 ns |         - |
|                                                  |              |              |             |             |              |           |
| TryComputeHash · Keccak-256 · CryptoHives-Arm64  | 128KB        | 189,206.2 ns | 3,721.98 ns | 5,570.89 ns | 189,521.7 ns |         - |
| TryComputeHash · Keccak-256 · BouncyCastle       | 128KB        | 707,148.5 ns | 8,663.15 ns | 8,103.52 ns | 706,807.5 ns |         - |
| TryComputeHash · Keccak-256 · CryptoHives-Scalar | 128KB        | 734,410.7 ns | 8,757.67 ns | 8,191.93 ns | 730,599.8 ns |         - |