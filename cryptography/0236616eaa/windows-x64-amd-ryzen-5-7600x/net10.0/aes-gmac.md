| Description                                | TestDataSize | Mean          | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|----------:|
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128B         |      65.01 ns |   0.241 ns |   0.226 ns |  11,437 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128B         |     479.93 ns |   3.859 ns |   3.421 ns |  21,191 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 137B         |      73.27 ns |   0.166 ns |   0.147 ns |  11,428 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 137B         |     495.77 ns |   2.813 ns |   2.493 ns |  21,748 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1KB          |     272.70 ns |   0.857 ns |   0.801 ns |  11,437 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1KB          |   1,316.98 ns |   5.352 ns |   5.006 ns |  21,177 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1025B        |     284.31 ns |   1.242 ns |   1.101 ns |  11,427 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1025B        |   1,308.62 ns |   3.793 ns |   3.362 ns |  21,765 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 8KB          |   1,935.74 ns |   9.526 ns |   7.955 ns |  11,201 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 8KB          |   7,745.71 ns |  12.932 ns |  11.464 ns |  20,909 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128KB        |  30,438.50 ns |  60.883 ns |  50.840 ns |  11,680 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128KB        | 121,882.84 ns | 168.036 ns | 131.191 ns |  21,088 B |    1816 B |