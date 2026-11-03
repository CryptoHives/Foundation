| Description                                | TestDataSize | Mean          | Error        | StdDev       | Allocated |
|------------------------------------------- |------------- |--------------:|-------------:|-------------:|----------:|
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128B         |      28.42 ns |     0.104 ns |     0.097 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128B         |     577.75 ns |     1.772 ns |     1.658 ns |    1728 B |
|                                            |              |               |              |              |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 137B         |      33.90 ns |     0.163 ns |     0.153 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 137B         |     603.92 ns |     2.306 ns |     2.157 ns |    1728 B |
|                                            |              |               |              |              |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1KB          |     128.92 ns |     0.901 ns |     0.843 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1KB          |   2,300.01 ns |     8.336 ns |     7.798 ns |    1728 B |
|                                            |              |               |              |              |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1025B        |     138.36 ns |     1.169 ns |     1.093 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1025B        |   2,318.24 ns |     5.145 ns |     4.296 ns |    1728 B |
|                                            |              |               |              |              |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 8KB          |   1,002.23 ns |     7.030 ns |     6.575 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 8KB          |  15,916.15 ns |    86.908 ns |    81.293 ns |    1728 B |
|                                            |              |               |              |              |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128KB        |  15,797.71 ns |   118.117 ns |   110.486 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128KB        | 253,904.59 ns | 1,275.507 ns | 1,193.110 ns |    1728 B |