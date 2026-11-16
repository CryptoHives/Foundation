| Description                                      | TestDataSize | Mean           | Error        | StdDev        | Median         | Code Size | Allocated |
|------------------------------------------------- |------------- |---------------:|-------------:|--------------:|---------------:|----------:|----------:|
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128B         |       838.4 ns |      6.65 ns |      13.14 ns |       837.0 ns |   5,456 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 128B         |     1,074.2 ns |      6.82 ns |      12.12 ns |     1,078.5 ns |   5,229 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128B         |     1,156.8 ns |      7.68 ns |      14.23 ns |     1,151.2 ns |   7,726 B |         - |
|                                                  |              |                |              |               |                |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 137B         |       825.6 ns |      2.11 ns |       3.81 ns |       825.5 ns |   5,457 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 137B         |     1,053.1 ns |      3.19 ns |       6.07 ns |     1,051.6 ns |   5,235 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 137B         |     1,150.6 ns |      4.07 ns |       7.23 ns |     1,147.7 ns |   7,723 B |         - |
|                                                  |              |                |              |               |                |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1KB          |     6,092.9 ns |     16.44 ns |      30.48 ns |     6,090.1 ns |   5,456 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 1KB          |     7,787.7 ns |     21.28 ns |      39.44 ns |     7,786.5 ns |   5,229 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1KB          |     8,286.8 ns |     26.04 ns |      46.95 ns |     8,268.4 ns |   7,712 B |         - |
|                                                  |              |                |              |               |                |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 1025B        |     6,078.2 ns |     13.31 ns |      24.67 ns |     6,074.2 ns |   5,458 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 1025B        |     7,868.7 ns |     40.46 ns |      73.98 ns |     7,840.1 ns |   5,231 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 1025B        |     8,298.3 ns |     16.46 ns |      29.68 ns |     8,291.4 ns |   7,708 B |         - |
|                                                  |              |                |              |               |                |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 8KB          |    45,609.0 ns |    140.30 ns |     256.55 ns |    45,539.3 ns |   5,456 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 8KB          |    59,957.8 ns |    762.89 ns |   1,432.89 ns |    59,045.1 ns |   5,229 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 8KB          |    62,683.9 ns |    157.67 ns |     296.15 ns |    62,646.3 ns |   7,704 B |         - |
|                                                  |              |                |              |               |                |           |           |
| TryComputeHash · Keccak-512 · CryptoHives-Scalar | 128KB        |   728,647.8 ns |  2,623.32 ns |   4,730.38 ns |   727,769.5 ns |   5,467 B |         - |
| TryComputeHash · Keccak-512 · BouncyCastle       | 128KB        | 1,002,581.2 ns |  4,350.58 ns |   8,064.08 ns | 1,000,502.5 ns |   7,722 B |         - |
| TryComputeHash · Keccak-512 · CryptoHives-AVX2   | 128KB        | 1,025,792.8 ns | 59,533.14 ns | 110,348.50 ns |   957,214.2 ns |   5,240 B |         - |