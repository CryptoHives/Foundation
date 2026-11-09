| Description                                | TestDataSize | Mean          | Error        | StdDev       | Code Size | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|----------:|
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128B         |      77.76 ns |     1.432 ns |     1.339 ns |  13,267 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128B         |     795.30 ns |    10.698 ns |    10.007 ns |  21,258 B |    1816 B |
|                                            |              |               |              |              |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 137B         |      84.33 ns |     1.423 ns |     1.331 ns |  13,273 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 137B         |     815.03 ns |    13.657 ns |    12.106 ns |  21,843 B |    1816 B |
|                                            |              |               |              |              |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1KB          |     177.68 ns |     3.230 ns |     3.021 ns |  13,267 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1KB          |   2,081.84 ns |    34.267 ns |    32.054 ns |  21,266 B |    1816 B |
|                                            |              |               |              |              |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1025B        |     185.41 ns |     1.144 ns |     1.070 ns |  13,273 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1025B        |   2,097.50 ns |    31.350 ns |    29.325 ns |  21,823 B |    1816 B |
|                                            |              |               |              |              |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 8KB          |     973.96 ns |    16.509 ns |    15.443 ns |  13,267 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 8KB          |  11,910.02 ns |   186.300 ns |   174.265 ns |  20,998 B |    1816 B |
|                                            |              |               |              |              |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128KB        |  15,138.47 ns |   234.881 ns |   219.708 ns |  13,267 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128KB        | 183,788.03 ns | 2,632.476 ns | 2,462.420 ns |  21,207 B |    1816 B |