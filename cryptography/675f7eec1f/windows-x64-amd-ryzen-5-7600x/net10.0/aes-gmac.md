| Description                                | TestDataSize | Mean          | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|----------:|
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128B         |      65.76 ns |     1.183 ns |     1.106 ns |  11,437 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128B         |     614.75 ns |    12.310 ns |    12.090 ns |  20,290 B |    1816 B |
|                                            |              |               |              |              |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 137B         |      75.48 ns |     1.114 ns |     1.042 ns |  11,425 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 137B         |     603.77 ns |     6.698 ns |     5.938 ns |  20,858 B |    1816 B |
|                                            |              |               |              |              |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1KB          |     272.91 ns |     5.391 ns |     7.197 ns |  11,437 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1KB          |   1,401.80 ns |    24.624 ns |    25.287 ns |  20,276 B |    1816 B |
|                                            |              |               |              |              |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1025B        |     276.64 ns |     4.519 ns |     4.641 ns |  11,427 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1025B        |   1,406.78 ns |    18.690 ns |    16.568 ns |  20,849 B |    1816 B |
|                                            |              |               |              |              |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 8KB          |   1,972.63 ns |    37.430 ns |    40.049 ns |  11,680 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 8KB          |   7,743.30 ns |   138.478 ns |   170.063 ns |  20,018 B |    1816 B |
|                                            |              |               |              |              |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128KB        |  30,787.63 ns |   546.650 ns |   456.477 ns |  11,680 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128KB        | 119,842.83 ns | 1,518.000 ns | 1,345.668 ns |  20,225 B |    1816 B |