| Description                                | TestDataSize | Mean         | Error    | StdDev   | Code Size | Allocated |
|------------------------------------------- |------------- |-------------:|---------:|---------:|----------:|----------:|
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128B         |     102.6 ns |  0.07 ns |  0.06 ns |  13,267 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128B         |   1,040.8 ns |  3.35 ns |  2.97 ns |  21,282 B |    1816 B |
|                                            |              |              |          |          |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 137B         |     111.3 ns |  0.04 ns |  0.04 ns |  13,273 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 137B         |   1,091.2 ns |  2.50 ns |  2.34 ns |  21,862 B |    1816 B |
|                                            |              |              |          |          |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1KB          |     234.5 ns |  0.26 ns |  0.24 ns |  13,267 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1KB          |   2,728.0 ns |  3.50 ns |  3.11 ns |  21,258 B |    1816 B |
|                                            |              |              |          |          |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1025B        |     242.3 ns |  0.26 ns |  0.25 ns |  13,273 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1025B        |   2,745.3 ns |  4.40 ns |  4.11 ns |  21,875 B |    1816 B |
|                                            |              |              |          |          |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 8KB          |   1,281.5 ns |  1.02 ns |  0.91 ns |  13,267 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 8KB          |  15,682.4 ns | 16.64 ns | 14.75 ns |  21,003 B |    1816 B |
|                                            |              |              |          |          |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128KB        |  19,926.4 ns | 84.58 ns | 70.63 ns |  13,516 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128KB        | 240,015.2 ns | 88.50 ns | 78.45 ns |  21,179 B |    1816 B |