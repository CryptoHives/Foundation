| Description                          | TestDataSize | Mean         | Error       | StdDev        | Median       | Allocated |
|------------------------------------- |------------- |-------------:|------------:|--------------:|-------------:|----------:|
| Decrypt · AES-256-CBC (Managed)      | 128B         |     1.236 μs |   0.0851 μs |     0.2509 μs |     1.200 μs |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128B         |     7.182 μs |   0.3590 μs |     1.0357 μs |     7.100 μs |    1512 B |
| Decrypt · AES-256-CBC (OS)           | 128B         |     7.829 μs |   1.1106 μs |     3.2745 μs |     7.150 μs |    1104 B |
|                                      |              |              |             |               |              |           |
| Encrypt · AES-256-CBC (Managed)      | 128B         |     1.075 μs |   0.0806 μs |     0.2326 μs |     1.100 μs |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128B         |     6.229 μs |   0.3079 μs |     0.8686 μs |     6.000 μs |    1496 B |
| Encrypt · AES-256-CBC (OS)           | 128B         |     7.014 μs |   0.8723 μs |     2.5583 μs |     6.900 μs |    1088 B |
|                                      |              |              |             |               |              |           |
| Decrypt · AES-256-CBC (Managed)      | 1KB          |     5.239 μs |   0.2293 μs |     0.6651 μs |     5.000 μs |         - |
| Decrypt · AES-256-CBC (OS)           | 1KB          |     7.650 μs |   0.9414 μs |     2.7756 μs |     7.100 μs |    2896 B |
| Decrypt · AES-256-CBC (BouncyCastle) | 1KB          |    32.776 μs |   1.2814 μs |     3.7175 μs |    31.400 μs |    3304 B |
|                                      |              |              |             |               |              |           |
| Encrypt · AES-256-CBC (Managed)      | 1KB          |     5.041 μs |   0.0947 μs |     0.2232 μs |     5.000 μs |         - |
| Encrypt · AES-256-CBC (OS)           | 1KB          |     6.124 μs |   0.6686 μs |     1.8749 μs |     5.600 μs |    2880 B |
| Encrypt · AES-256-CBC (BouncyCastle) | 1KB          |    32.671 μs |   1.3881 μs |     4.0493 μs |    31.000 μs |    3288 B |
|                                      |              |              |             |               |              |           |
| Decrypt · AES-256-CBC (OS)           | 8KB          |     9.841 μs |   1.0766 μs |     3.1745 μs |     9.700 μs |   17232 B |
| Decrypt · AES-256-CBC (Managed)      | 8KB          |    40.372 μs |   1.6097 μs |     4.6700 μs |    38.100 μs |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 8KB          |   237.648 μs |   9.8149 μs |    28.6306 μs |   218.950 μs |   17640 B |
|                                      |              |              |             |               |              |           |
| Encrypt · AES-256-CBC (OS)           | 8KB          |    13.782 μs |   1.0478 μs |     3.0565 μs |    13.250 μs |   17216 B |
| Encrypt · AES-256-CBC (Managed)      | 8KB          |    40.844 μs |   1.6642 μs |     4.7749 μs |    38.300 μs |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 8KB          |   232.221 μs |   9.0749 μs |    26.3278 μs |   216.500 μs |   17624 B |
|                                      |              |              |             |               |              |           |
| Decrypt · AES-256-CBC (OS)           | 128KB        |    40.230 μs |   1.7884 μs |     5.2168 μs |    39.300 μs |  262992 B |
| Decrypt · AES-256-CBC (Managed)      | 128KB        |   564.232 μs |  21.9798 μs |    63.4167 μs |   578.050 μs |         - |
| Decrypt · AES-256-CBC (BouncyCastle) | 128KB        | 2,281.098 μs | 500.0453 μs | 1,474.3950 μs | 3,318.650 μs |  263400 B |
|                                      |              |              |             |               |              |           |
| Encrypt · AES-256-CBC (OS)           | 128KB        |   117.064 μs |   5.1113 μs |    15.0708 μs |   108.850 μs |  262976 B |
| Encrypt · AES-256-CBC (Managed)      | 128KB        |   579.833 μs |  22.5228 μs |    64.9833 μs |   631.400 μs |         - |
| Encrypt · AES-256-CBC (BouncyCastle) | 128KB        | 1,584.051 μs | 459.6003 μs | 1,355.1421 μs |   743.650 μs |  263384 B |