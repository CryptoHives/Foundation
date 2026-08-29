| Description                                      | TestDataSize | Mean         | Error       | StdDev       | Median       | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|-------------:|-------------:|----------:|
| TryComputeHash · Keccak-384 · BouncyCastle       | 128B         |     319.8 ns |     4.80 ns |      4.49 ns |     318.8 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128B         |     326.6 ns |     4.85 ns |      7.83 ns |     323.1 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 128B         |   1,414.3 ns |     2.95 ns |      2.61 ns |   1,413.4 ns |         - |
|                                                  |              |              |             |              |              |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 137B         |     300.8 ns |     0.51 ns |      0.46 ns |     300.6 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 137B         |     324.5 ns |     1.87 ns |      1.75 ns |     324.2 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 137B         |     326.2 ns |     0.73 ns |      0.61 ns |     326.2 ns |         - |
|                                                  |              |              |             |              |              |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 1KB          |   1,494.9 ns |     1.69 ns |      1.41 ns |   1,494.5 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1KB          |   1,599.0 ns |     2.78 ns |      2.32 ns |   1,598.9 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1KB          |   1,666.4 ns |    32.96 ns |     89.68 ns |   1,667.5 ns |         - |
|                                                  |              |              |             |              |              |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 1025B        |   1,903.1 ns |    32.50 ns |     30.40 ns |   1,898.1 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 1025B        |   1,949.0 ns |    38.08 ns |     53.39 ns |   1,951.4 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 1025B        |   3,288.9 ns |   908.90 ns |  2,679.92 ns |   1,568.6 ns |         - |
|                                                  |              |              |             |              |              |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 8KB          |  11,778.7 ns |    28.12 ns |     21.96 ns |  11,774.7 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 8KB          |  11,911.0 ns |   128.55 ns |    113.96 ns |  11,867.5 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 8KB          |  12,574.6 ns |    18.46 ns |     17.26 ns |  12,576.2 ns |         - |
|                                                  |              |              |             |              |              |           |
| TryComputeHash · Keccak-384 · CryptoHives-Arm64  | 128KB        | 211,066.4 ns | 3,945.16 ns |  5,782.77 ns | 211,464.4 ns |         - |
| TryComputeHash · Keccak-384 · BouncyCastle       | 128KB        | 225,788.9 ns | 4,436.70 ns |  7,533.86 ns | 227,504.1 ns |         - |
| TryComputeHash · Keccak-384 · CryptoHives-Scalar | 128KB        | 235,068.3 ns | 4,691.98 ns | 10,494.29 ns | 237,420.9 ns |         - |